using Foundation;
using IdesseCaseStudy.iOS.DependencyServices;
using IdesseCaseStudy.Resources.Languages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace IdesseCaseStudy.iOS.DependencyServices
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            var prefLang = "en";

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                prefLang = pref.Substring(0, 2);
                netLanguage = pref.Replace("_", "-");
            }

            CultureInfo ci = null;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (Exception)
            {
                ci = new CultureInfo(prefLang);
            }

            return ci;
        }

        public void SetLocale()
        {
            var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            var netLocale = iosLocaleAuto.Replace("_", "-");
            CultureInfo ci;
            try
            {
                ci = new CultureInfo(netLocale);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ci = null;
            }

            if (ci != null)
            {
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }
        }

        public void SetLocale(string lang)
        {
            CultureInfo ci;
            try
            {
                ci = new CultureInfo(lang);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ci = null;
            }

            if (ci != null)
            {
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }
        }
    }
}