using IdesseCaseStudy.Models;
using IdesseCaseStudy.Pages;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IdesseCaseStudy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            //if (Preferences.ContainsKey("user"))
            //{
            //    var user = Preferences.Get("user", "");
            //    if (!string.IsNullOrEmpty(user))
            //    {
            //        App.CurrentUser = JsonConvert.DeserializeObject<User>(user);
            //        Application.Current.MainPage = new MenuPage();
            //        return;
            //    }
            //}

            Application.Current.MainPage = new LoginPage();
        }
    }
}
