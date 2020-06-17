using System;
using CoreAnimation;
using CoreGraphics;
using GradientBackground.Enums;
using GradientBackground.iOS.Renderers;
using GradientBackground.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientNavigationPage), typeof(GradientNavigationPageRenderer))]

namespace GradientBackground.iOS.Renderers
{
    public class GradientNavigationPageRenderer : NavigationRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (NavigationBar == null)
                return;

            SetGradientBackground();
        }

        private void SetGradientBackground()
        {
            var control = (GradientNavigationPage)this.Element;

            var gradientLayer = new CAGradientLayer();

            switch (control.Direction)
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

            // --> Get StatusBarFrame size:
            var statusBarSize = UIApplication.SharedApplication.StatusBarFrame.Size;

            // --> Set Height and Width of StatusBarFrame size:
            var statusBar = Math.Min(statusBarSize.Height, statusBarSize.Width);

            // --> Set NavigationBar Bounds:
            var navigationBarBounds = new CGRect(
                NavigationBar.Bounds.X,
                NavigationBar.Bounds.Y,
                NavigationBar.Bounds.Width,
                statusBar + NavigationBar.Bounds.Height);

            gradientLayer.Bounds = navigationBarBounds;
            gradientLayer.Colors = new CGColor[] { control.StartColor.ToCGColor(), control.EndColor.ToCGColor() };
            UIGraphics.BeginImageContext(gradientLayer.Bounds.Size);
            gradientLayer.RenderInContext(UIGraphics.GetCurrentContext());
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            NavigationBar.SetBackgroundImage(image, UIBarMetrics.Default);

            // --> To Change Navigation Bar Icon Color:
            NavigationBar.TintColor = Color.White.ToUIColor();

            // --> Hide Navigation Bar Separator:
            //NavigationBar.ShadowImage = new UIImage();
        }
    }
}
