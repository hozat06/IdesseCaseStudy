using Plugin.Toasts;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IdesseCaseStudy.Managers
{
    public static class ToastManager
    {
        private static IToastNotificator notificator;

        static ToastManager()
        {
            notificator = DependencyService.Get<IToastNotificator>();
        }

        private static void Show(ToastNotificationType type, string message, string title = "Idesse")
        {
           notificator.Notify(type, title, message, TimeSpan.FromSeconds(3000), clickable: false);
        }

        public static void Success(string message, string title = "Idesse") => Show(ToastNotificationType.Success, message, title);
        public static void Info(string message, string title = "Idesse") => Show(ToastNotificationType.Info, message, title);
        public static void Error(string message, string title = "Idesse") => Show(ToastNotificationType.Error, message, title);
        public static void Warning(string message, string title = "Idesse") => Show(ToastNotificationType.Warning, message, title);
    }
}
