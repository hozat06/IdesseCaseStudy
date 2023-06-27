using IdesseCaseStudy.ModelViews;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdesseCaseStudy.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPageFlyout : ContentPage
    {
        private MenuViewModel menuViewModel;
        public MenuPageFlyout()
        {
            InitializeComponent();
            menuViewModel = new MenuViewModel();
            this.BindingContext = menuViewModel;
        }

        private void ListMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var item = (MenuPageFlyoutMenuItem)e.SelectedItem;
            if (item != null)
            {
                menuViewModel.MenuItemSelected(item);
            }

            listMenu.SelectedItem = null;
        }
    }
}