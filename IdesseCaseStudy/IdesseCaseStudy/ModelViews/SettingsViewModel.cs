using IdesseCaseStudy.Managers;
using IdesseCaseStudy.Resources.Languages;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IdesseCaseStudy.ModelViews
{
    public class SettingsViewModel : BaseViewModel
    {
        public List<string> Languages { get; } = new List<string>
        {
            AppLanguage._Shared_LanguageTR,
            AppLanguage._Shared_LanguageEN
        };

        private string language;
        public string Language
        {
            get => language;
            set
            {
                if (language != value)
                {
                    language = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveCommand { get; private set; }

        private void Save()
        {
            if (string.IsNullOrEmpty(Language))
            {
                ToastManager.Error(AppLanguage.SettingsPage_LanguageChoose);
                return;
            }

            string currentLanguage = "";
            if (Language == AppLanguage._Shared_LanguageTR) currentLanguage = "tr-TR";
            else currentLanguage = "en-US";

            Preferences.Set("Language", currentLanguage);
            AppLanguage.Culture = new System.Globalization.CultureInfo(currentLanguage);
            DependencyService.Get<ILocalize>().SetLocale(currentLanguage);

            ToastManager.Success(AppLanguage.SettingsPage_Save);
        }

        public SettingsViewModel()
        {
            var currentLanguage = Preferences.Get("Language", "");
            if (String.IsNullOrEmpty(currentLanguage))
            {
                DependencyService.Get<ILocalize>().SetLocale();
                System.Globalization.CultureInfo lang = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                if (lang.Name.Contains("tr"))
                    currentLanguage = "tr-TR";
                else
                    currentLanguage = "en-US";
            }
            Language = currentLanguage == "tr-TR" ? AppLanguage._Shared_LanguageTR : AppLanguage._Shared_LanguageEN;

            SaveCommand = new Command(() => Save());
        }
    }
}
