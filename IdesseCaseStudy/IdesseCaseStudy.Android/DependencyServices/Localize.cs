using IdesseCaseStudy.Droid.DependencyServices;
using IdesseCaseStudy.Resources.Languages;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]
namespace IdesseCaseStudy.Droid.DependencyServices
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLocale = androidLocale.ToString().Replace("_", "-");

            return new CultureInfo(netLocale);
        }

        public void SetLocale()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLocale = androidLocale.ToString().Replace("_", "-");

            var ci = new CultureInfo(netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public void SetLocale(string lang)
        {
            var ci = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}