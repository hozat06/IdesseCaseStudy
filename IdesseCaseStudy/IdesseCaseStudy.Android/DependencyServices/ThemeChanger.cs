using IdesseCaseStudy.Droid.DependencyServices;
using IdesseCaseStudy.Resources.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(ThemeChanger))]
namespace IdesseCaseStudy.Droid.DependencyServices
{
    public class ThemeChanger : IThemeChanger
    {
        public void ApplyTheme()
        {
            MainActivity.mainActivity.SetTheme(Resource.Style.MainTheme);
        }
    }
}