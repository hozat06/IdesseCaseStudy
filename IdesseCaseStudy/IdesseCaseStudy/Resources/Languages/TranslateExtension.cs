using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IdesseCaseStudy.Resources.Languages
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "IdesseCaseStudy.Resources.Languages.AppLanguage";
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;

            ResourceManager resourceManager = new ResourceManager(ResourceId, 
                typeof(TranslateExtension).GetTypeInfo().Assembly);

            return resourceManager.GetString(Text, CultureInfo.CurrentCulture);
        }
    }
}
