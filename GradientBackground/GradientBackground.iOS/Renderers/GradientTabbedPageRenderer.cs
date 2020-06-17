using CoreAnimation;
using CoreGraphics;
using GradientBackground.Enums;
using GradientBackground.iOS.Renderers;
using GradientBackground.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientTabbedPage), typeof(GradientTabbedPageRenderer))]

namespace GradientBackground.iOS.Renderers
{
    public class GradientTabbedPageRenderer : TabbedRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (TabBar == null)
                return;

            SetGradientBackground();
        }

        private void SetGradientBackground()
        {
            var control = (GradientTabbedPage)this.Element;

            var gradientLayer = new CAGradientLayer();

            switch (control.TabBarDirection)
            {
                default:
                case GradientDirection.ToRight:
                    gradientLayer.StartPoint = new CGPoint(0, 0.5);
                    gradientLayer.EndPoint = new CGPoint(1, 0.5);
                    break;
                case GradientDirection.ToLeft:
                    gradientLayer.StartPoint = new CGPoint(1, 0.5);
                    gradientLayer.EndPoint = new CGPoint(0, 0.5);
                    break;
                case GradientDirection.ToTop:
                    gradientLayer.StartPoint = new CGPoint(0.5, 0);
                    gradientLayer.EndPoint = new CGPoint(0.5, 1);
                    break;
                case GradientDirection.ToBottom:
                    gradientLayer.StartPoint = new CGPoint(0.5, 1);
                    gradientLayer.EndPoint = new CGPoint(0.5, 0);
                    break;
                case GradientDirection.ToTopLeft:
                    gradientLayer.StartPoint = new CGPoint(1, 0);
                    gradientLayer.EndPoint = new CGPoint(0, 1);
                    break;
                case GradientDirection.ToTopRight:
                    gradientLayer.StartPoint = new CGPoint(0, 1);
                    gradientLayer.EndPoint = new CGPoint(1, 0);
                    break;
                case GradientDirection.ToBottomLeft:
                    gradientLayer.StartPoint = new CGPoint(1, 1);
                    gradientLayer.EndPoint = new CGPoint(0, 0);
                    break;
                case GradientDirection.ToBottomRight:
                    gradientLayer.StartPoint = new CGPoint(0, 0);
                    gradientLayer.EndPoint = new CGPoint(1, 1);
                    break;
            }
            gradientLayer.Bounds = TabBar.Bounds;
            gradientLayer.Colors = new CGColor[] { control.TabBarStartColor.ToCGColor(), control.TabBarEndColor.ToCGColor() };
            UIGraphics.BeginImageContext(gradientLayer.Frame.Size);
            CGContext currentContext = UIGraphics.GetCurrentContext();
            gradientLayer.RenderInContext(currentContext);
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            // --> Space adjustment from ()top/left/bottom/right) for Icon and (horizontal/vertical) for Title
            foreach (var tabbarItem in TabBar.Items)
            {
                // --> Leave some space from Top of Icon. UIEdgeInsets(top, left, bottom, right)
                tabbarItem.ImageInsets = new UIEdgeInsets(6, 0, 0, 0);

                // --> Leave some space from Top and Bottom of Title. UIOffset(horizontal, vertical)
                tabbarItem.TitlePositionAdjustment = new UIOffset(0, 6);
            }

            TabBar.BackgroundImage = image;

            // --> Hide TabBar Separator:
            //TabBar.ShadowImage = new UIImage();
        }
    }
}
