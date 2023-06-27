using IdesseCaseStudy.Resources.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdesseCaseStudy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : FlyoutPage
    {
        private static MenuPage _menuPage;
        public static void SetDetailPage(MenuPageFlyoutMenuItem item)
        {
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            _menuPage.Detail = new NavigationPage(page);
            _menuPage.IsPresented = false;
        }

        public MenuPage()
        {
            InitializeComponent();
            _menuPage = this;
            if (Device.RuntimePlatform == Device.Android) DependencyService.Get<IThemeChanger>().ApplyTheme();
        }
    }
}