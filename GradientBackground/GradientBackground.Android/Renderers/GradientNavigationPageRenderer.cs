using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Views;
using GradientBackground.Droid.Renderers;
using GradientBackground.Enums;
using GradientBackground.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(GradientNavigationPage), typeof(GradientNavigationPageRenderer))]

namespace GradientBackground.Droid.Renderers
{
    public class GradientNavigationPageRenderer : NavigationPageRenderer
    {
        GradientDrawable gradientDrawable;
        Toolbar toolbar;

        public GradientNavigationPageRenderer(Context context)
            : base(context)
        {
        }

        public override void AddView(Android.Views.View child)
        {
            base.AddView(child);

            var context = (MainActivity)this.Context;
            context.Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            // --> Set Status Bar Gradient:
            context.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);

            // --> Set Navigation Bar Gradient:
            context.Window.SetNavigationBarColor(Android.Graphics.Color.Transparent);

            context.Window.SetBackgroundDrawable(gradientDrawable);

            SetGradientBackground();
        }

        private void SetGradientBackground()
        {
            var control = (GradientNavigationPage)this.Element;

            int[] colors = new int[] { control.StartColor.ToAndroid().ToArgb(), control.EndColor.ToAndroid().ToArgb() };

            switch (control.Direction)
            {
                default:
                case GradientDirection.ToRight:
                    gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.LeftRight, colors);
                    break;
                case GradientDirection.ToLeft:
                    gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.RightLeft, colors);
                    break;
                case GradientDirection.ToTop:
                    gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.BottomTop, colors);
                    break;
                case GradientDirection.ToBottom:
                    gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.TopBottom, colors);
                    break;
                case GradientDirection.ToTopLeft:
                    gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.BrTl, colors);
                    break;
                case GradientDirection.ToTopRight:
                    gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.BlTr, colors);
                    break;
                case GradientDirection.ToBottomLeft:
                    gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.TrBl, colors);
                    break;
                case GradientDirection.ToBottomRight:
                    gradientDrawable = new GradientDrawable(GradientDrawable.Orientation.TlBr, colors);
                    break;
            }
            gradientDrawable.SetCornerRadius(0f);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.SetBackground(gradientDrawable);
        }
    }
}
