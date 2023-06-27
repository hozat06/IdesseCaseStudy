using IdesseCaseStudy.Managers;
using IdesseCaseStudy.Models;
using IdesseCaseStudy.Pages;
using IdesseCaseStudy.Resources.Languages;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IdesseCaseStudy.ModelViews
{
    public class MenuViewModel : BaseViewModel
    {
        public User CurrentUser
        {
            get => App.CurrentUser;
            set
            {
                if (App.CurrentUser != value)
                {
                    App.CurrentUser = value;
                    Preferences.Set("user", JsonConvert.SerializeObject(App.CurrentUser));
                    OnPropertyChanged();
                }
            }
        }

        private string search;
        public string Search
        {
            get => search;
            set
            {
                if (search != value)
                {
                    search = value;
                    OnPropertyChanged();
                }
            }
        }

        private readonly ObservableCollection<MenuPageFlyoutMenuItem> _menuItems;
        private ObservableCollection<MenuPageFlyoutMenuItem> menuItems;
        public ObservableCollection<MenuPageFlyoutMenuItem> MenuItems
        {
            get => menuItems;
            set
            {
                if (menuItems != value)
                {
                    menuItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand MenuItemSelectedCommand { get; set; }
        public ICommand MenuItemSearchCommand { get; set; }

        public MenuViewModel()
        {
            CurrentUser = App.CurrentUser;
            _menuItems = new ObservableCollection<MenuPageFlyoutMenuItem>()
            {
                new MenuPageFlyoutMenuItem(1,AppLanguage.Menu_Item_Home,"\xf015", Color.FromHex("#1E3050"),false,typeof(HomePage)),
                new MenuPageFlyoutMenuItem(2,AppLanguage.Menu_Item_Calendar,"\xf073", Color.FromHex("#1E3050"),false,typeof(CalendarPage)),
                new MenuPageFlyoutMenuItem(3,AppLanguage.Menu_Item_Orders,"\xf07a", Color.FromHex("#1E3050"),false,typeof(OrderPage)),
                new MenuPageFlyoutMenuItem(4,AppLanguage.Menu_Item_Persons,"\xf0c0", Color.FromHex("#1E3050"),true,typeof(PersonsPage)),
                new MenuPageFlyoutMenuItem(5,AppLanguage.Menu_Item_Units,"\xf5fd", Color.FromHex("#1E3050"),false,typeof(UnitPage)),
                new MenuPageFlyoutMenuItem(6,AppLanguage.Menu_Item_CLM,"\xf04b", Color.FromHex("#1E3050"),false,typeof(CLMPage)),
                new MenuPageFlyoutMenuItem(7,AppLanguage.Menu_Item_Settings,"\xf013", Color.FromHex("#1E3050"),false,typeof(SettingsPage)),
                new MenuPageFlyoutMenuItem(8,AppLanguage.Menu_Item_LogOut,"\xf011", Color.FromHex("#FF334E"),false,null),
            };
            menuItems = new ObservableCollection<MenuPageFlyoutMenuItem>();
            foreach (var item in _menuItems)
                menuItems.Add(item);

            OnPropertyChanged(nameof(MenuItems));

            MenuItemSelectedCommand = new Command<MenuPageFlyoutMenuItem>(item => MenuItemSelected(item));
            MenuItemSearchCommand = new Command(()=> MenuItemSearch());
        }

        public async void MenuItemSelected(MenuPageFlyoutMenuItem item)
        {
            if (item.Id == 8)
            {
                if (await Application.Current.MainPage.DisplayAlert(AppLanguage._Shared_Title, AppLanguage._Shared_Logout_Message, AppLanguage._Shared_Yes, AppLanguage._Shared_No))
                {
                    App.CurrentUser = null;
                    Preferences.Remove("user");
                    Application.Current.MainPage = new LoginPage();
                }
            }
            else
            {
                menuItems.Clear();
                foreach (var menuItem in _menuItems)
                {
                    menuItem.Selected = menuItem.Id == item.Id;
                    menuItems.Add(menuItem);
                }
                OnPropertyChanged(nameof(MenuItems));

                MenuPage.SetDetailPage(item);
            }
        }
        private void MenuItemSearch()
        {
            menuItems.Clear();
            foreach (var menuItem in _menuItems.Where(x=> x.Title.ToLower().StartsWith(Search.ToLower())).ToList())
                menuItems.Add(menuItem);

            OnPropertyChanged(nameof(MenuItems));
        }
    }
}
