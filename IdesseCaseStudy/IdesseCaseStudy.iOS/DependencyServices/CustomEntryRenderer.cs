using IdesseCaseStudy.iOS.DependencyServices;
using IdesseCaseStudy.Resources.CustomControls;
using System.Drawing;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace IdesseCaseStudy.iOS.DependencyServices
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var view = (CustomEntry)Element;
                UITextField textField = Control;
                Control.BorderStyle = UITextBorderStyle.None;

                this.AddDoneButton();
            }
        }

        // <summary>
        /// <para>Add toolbar with Done button</para>
        /// </summary>
        protected void AddDoneButton()
        {
            var toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, 50.0f, 44.0f));

            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
            {
                this.Control.ResignFirstResponder();
                var baseEntry = this.Element.GetType();
                ((IEntryController)Element).SendCompleted();
            });

            toolbar.Items = new UIBarButtonItem[] {
                new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace),
                doneButton
            };
            this.Control.InputAccessoryView = toolbar;
        }
    }
}