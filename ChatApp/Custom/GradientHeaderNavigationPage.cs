using System;

namespace ChatApp.Custom
{
    public class GradientHeaderNavigationPage : NavigationPage
    {
        public GradientHeaderNavigationPage(Page page) : base(page)
        {
            BarTextColor = Color.FromArgb("FFFFFF");
        }
    }
}