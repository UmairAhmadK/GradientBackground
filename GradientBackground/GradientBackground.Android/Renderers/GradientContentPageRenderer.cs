using Android.Content;
using Android.Graphics;
using GradientBackground.Droid.Renderers;
using GradientBackground.Enums;
using GradientBackground.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientContentPage), typeof(GradientContentPageRenderer))]

namespace GradientBackground.Droid.Renderers
{
    public class GradientContentPageRenderer : PageRenderer
    {
        public GradientContentPageRenderer(Context context)
            : base(context)
        {
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            LinearGradient linearGradient;

            var control = (GradientContentPage)Element;

            int[] colors = new int[] { control.StartColor.ToAndroid().ToArgb(), control.EndColor.ToAndroid().ToArgb() };

            switch (control.Direction)
            {
                default:
                case GradientDirection.ToRight:
                    linearGradient = new LinearGradient(0, 0, Width, 0, colors, null, Shader.TileMode.Mirror);
                    break;
                case GradientDirection.ToLeft:
                    linearGradient = new LinearGradient(Width, 0, 0, 0, colors, null, Shader.TileMode.Mirror);
                    break;
                case GradientDirection.ToTop:
                    linearGradient = new LinearGradient(0, Height, 0, 0, colors, null, Shader.TileMode.Mirror);
                    break;
                case GradientDirection.ToBottom:
                    linearGradient = new LinearGradient(0, 0, 0, Height, colors, null, Shader.TileMode.Mirror);
                    break;
                case GradientDirection.ToTopLeft:
                    linearGradient = new LinearGradient(Width, Height, 0, 0, colors, null, Shader.TileMode.Mirror);
                    break;
                case GradientDirection.ToTopRight:
                    linearGradient = new LinearGradient(0, Height, Width, 0, colors, null, Shader.TileMode.Mirror);
                    break;
                case GradientDirection.ToBottomLeft:
                    linearGradient = new LinearGradient(Width, 0, 0, Height, colors, null, Shader.TileMode.Mirror);
                    break;
                case GradientDirection.ToBottomRight:
                    linearGradient = new LinearGradient(0, 0, Width, Height, colors, null, Shader.TileMode.Mirror);
                    break;
            }
            var paint = new Paint()
            {
                Dither = true,
            };
            paint.SetShader(linearGradient);
            canvas.DrawPaint(paint);
            base.DispatchDraw(canvas);
        }
    }
}
