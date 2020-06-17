using GradientBackground.Enums;
using Xamarin.Forms;

namespace GradientBackground.Renderers
{
    public class GradientTabbedPage : TabbedPage
    {
        public static readonly BindableProperty TabBarStartColorProperty =
            BindableProperty.Create(
                propertyName: nameof(TabBarStartColor),
                returnType: typeof(Color),
                declaringType: typeof(GradientNavigationPage),
                defaultValue: Color.FromHex("#2196F3"));

        public static readonly BindableProperty TabBarEndColorProperty =
            BindableProperty.Create(
                propertyName: nameof(TabBarEndColor),
                returnType: typeof(Color),
                declaringType: typeof(GradientNavigationPage),
                defaultValue: Color.FromHex("#2196F3"));

        public static readonly BindableProperty TabBarDirectionProperty =
            BindableProperty.Create(
                propertyName: nameof(TabBarDirection),
                returnType: typeof(GradientDirection),
                declaringType: typeof(GradientNavigationPage),
                defaultValue: GradientDirection.ToRight);

        public Color TabBarStartColor
        {
            get { return (Color)GetValue(TabBarStartColorProperty); }
            set { SetValue(TabBarStartColorProperty, value); }
        }

        public Color TabBarEndColor
        {
            get { return (Color)GetValue(TabBarEndColorProperty); }
            set { SetValue(TabBarEndColorProperty, value); }
        }

        public GradientDirection TabBarDirection
        {
            get { return (GradientDirection)GetValue(TabBarDirectionProperty); }
            set { SetValue(TabBarDirectionProperty, value); }
        }
    }
}
