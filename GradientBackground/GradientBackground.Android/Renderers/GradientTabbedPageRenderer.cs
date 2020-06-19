using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Util;
using GradientBackground.Droid.Renderers;
using GradientBackground.Enums;
using GradientBackground.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(GradientTabbedPage), typeof(GradientTabbedPageRenderer))]

namespace GradientBackground.Droid.Renderers
{
    public class GradientTabbedPageRenderer : TabbedPageRenderer
    {
        TabLayout tabLayout;
        BottomNavigationView bottomNavigationView;
        GradientDrawable gradientDrawable;

        public GradientTabbedPageRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            SetGradientBackground();

            var relativeLayout = this.GetChildAt(0) as Android.Widget.RelativeLayout;

            if (relativeLayout == null)
            {
                tabLayout = FindViewById<TabLayout>(Resource.Id.sliding_tabs);
                tabLayout.SetBackground(gradientDrawable);
            }
            else
            {
                ColorStateList iconsColorStates = new ColorStateList(
                    new int[][]{
                        new int[]{-Android.Resource.Attribute.StateChecked },
                        new int[]{ Android.Resource.Attribute.StateChecked }
                    },
                    new int[]{
                        Android.Graphics.Color.AliceBlue,
                        Android.Graphics.Color.White
                    });

                ColorStateList textColorStates = new ColorStateList(
                    new int[][]{
                        new int[]{-Android.Resource.Attribute.StateChecked },
                        new int[]{ Android.Resource.Attribute.StateChecked }
                        },
                    new int[]{
                        Android.Graphics.Color.AliceBlue,
                        Android.Graphics.Color.White
                    });
                bottomNavigationView = relativeLayout.GetChildAt(1) as BottomNavigationView;

                // --> Individually resize Tab bar icons on BottomNavigationView:
                //var bottomNavigationMenuView = (BottomNavigationMenuView)bottomNavigationView.GetChildAt(0);
                //var scale = Resources.DisplayMetrics.Density;
                //var paddingDp = 4;
                //var dpAsPixels = (int)(paddingDp * scale + 0.5f);
                //for (int i = 0; i < bottomNavigationMenuView.ChildCount; i++)
                //{
                //    var childView = bottomNavigationMenuView.GetChildAt(i);
                //    var iconView = bottomNavigationMenuView.GetChildAt(i).FindViewById(Resource.Id.icon);
                //    var layoutParams = iconView.LayoutParameters;
                //    var displayMetrics = Resources.DisplayMetrics;
                //    // --> If it is special menu item change the size, otherwise take other size:
                //    if (i == 1)
                //    {
                //        // --> Set Padding individually:
                //        //if (childView is BottomNavigationItemView tab)
                //        //{
                //        //    // --> Set Padding here:
                //        //    tab.SetPadding(tab.PaddingLeft, dpAsPixels, tab.PaddingRight, tab.PaddingBottom);
                //        //}

                //        // --> Set height here:
                //        layoutParams.Height = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 32, displayMetrics);

                //        // --> Set width here:
                //        layoutParams.Width = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 48, displayMetrics);
                //    }
                //    else if (i == 2)
                //    {
                //        // --> Set Padding individually:
                //        //if (childView is BottomNavigationItemView tab)
                //        //{
                //        //    // --> Set Padding here:
                //        //    tab.SetPadding(tab.PaddingLeft, dpAsPixels, tab.PaddingRight, tab.PaddingBottom);
                //        //}

                //        // --> Set height here:
                //        layoutParams.Height = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 24, displayMetrics);

                //        // --> Set width here:
                //        layoutParams.Width = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 24, displayMetrics);
                //    }
                //    else
                //    {
                //        // --> Set Padding individually:
                //        //if (childView is BottomNavigationItemView tab)
                //        //{
                //        //    // --> Set Padding here:
                //        //    tab.SetPadding(tab.PaddingLeft, dpAsPixels, tab.PaddingRight, tab.PaddingBottom);
                //        //}

                //        // --> Set height here:
                //        layoutParams.Height = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 28, displayMetrics);

                //        // --> Set width here:
                //        layoutParams.Width = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 28, displayMetrics);
                //    }
                //    iconView.LayoutParameters = layoutParams;
                //}

                // --> Resize all Tab bar icons equally on BottomNavigationView:
                //bottomNavigationView.ItemIconSize = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 80, Resources.DisplayMetrics);

                bottomNavigationView.ItemIconTintList = iconsColorStates;
                bottomNavigationView.ItemTextColor = textColorStates;

                // --> Set Padding for all icons equally:
                bottomNavigationView.SetPadding(0, 15, 0, 0);

                bottomNavigationView.SetBackground(gradientDrawable);
                bottomNavigationView.Elevation = 0;
            }
        }

        private void SetGradientBackground()
        {
            var control = (GradientTabbedPage)this.Element;

            int[] colors = new int[] { control.TabBarStartColor.ToAndroid().ToArgb(), control.TabBarEndColor.ToAndroid().ToArgb() };

            switch (control.TabBarDirection)
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
            gradientDrawable.SetShape(ShapeType.Rectangle);
        }
    }
}
