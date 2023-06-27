using IdesseCaseStudy.Models;
using IdesseCaseStudy.Resources.Languages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IdesseCaseStudy
{
    public partial class App : Application
    {
        public static User CurrentUser { get; set; }

        public App()
        {
            InitializeComponent();

            string currentLanguage = Preferences.Get("Language", "");
            if (!String.IsNullOrEmpty(currentLanguage))
            {
                AppLanguage.Culture = new System.Globalization.CultureInfo(currentLanguage);
                DependencyService.Get<ILocalize>().SetLocale(currentLanguage);
            }
            else
            {
                DependencyService.Get<ILocalize>().SetLocale();
                var lang = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                if (lang.Name.Contains("tr"))
                {
                    AppLanguage.Culture = new System.Globalization.CultureInfo("tr-TR");
                    Preferences.Set("Language", "tr-TR");
                }
                else
                {
                    AppLanguage.Culture = new System.Globalization.CultureInfo("en-US");
                    Preferences.Set("Language", "en-US");
                }
            }

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
