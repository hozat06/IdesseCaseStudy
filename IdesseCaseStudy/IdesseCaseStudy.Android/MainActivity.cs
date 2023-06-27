
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace IdesseCaseStudy.Droid
{
    [Activity(Label = "Idesse Case Study",
        Icon = "@mipmap/icon",
        Theme = "@style/MyTheme.Splash",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize |
                               ConfigChanges.Orientation |
                               ConfigChanges.UiMode |
                               ConfigChanges.ScreenLayout |
                               ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity mainActivity { get; private set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            mainActivity = this;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //--Plugins

            Acr.UserDialogs.UserDialogs.Init(this);

            Xamarin.Forms.DependencyService.Register<Plugin.Toasts.ToastNotificatorImplementation>();
            Plugin.Toasts.ToastNotificatorImplementation.Init(this);

            //--.Plugins

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}