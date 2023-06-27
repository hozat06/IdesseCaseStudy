namespace IdesseCaseStudy.Resources.Languages
{
    public interface ILocalize
    {
        void SetLocale();
        void SetLocale(string lang);
        System.Globalization.CultureInfo GetCurrentCultureInfo();
    }
}
