using Android.Content;
using IdesseCaseStudy.Droid.DependencyServices;
using IdesseCaseStudy.Resources.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace IdesseCaseStudy.Droid.DependencyServices
{
    public class CustomEntryRenderer : EntryRenderer
    {
        CustomEntry view;

        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = null;
            }
        }
    }
}