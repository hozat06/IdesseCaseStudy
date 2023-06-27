using System;
using Xamarin.Forms;

namespace IdesseCaseStudy.Pages
{
    public class MenuPageFlyoutMenuItem
    {
        public MenuPageFlyoutMenuItem()
        {
            TargetType = typeof(MenuPageFlyoutMenuItem);
        }

        public MenuPageFlyoutMenuItem(int id, string title, string icon, Color iconColor, bool selected, Type targetType)
        {
            Id = id;
            Title = title;
            Icon = icon;
            IconColor = iconColor;
            Selected = selected;
            TargetType = targetType;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public Color IconColor { get; set; }
        public bool Selected { get; set; }

        public Type TargetType { get; set; }

    }
}