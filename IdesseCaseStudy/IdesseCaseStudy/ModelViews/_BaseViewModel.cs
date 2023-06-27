using IdesseCaseStudy.Resources.Languages;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IdesseCaseStudy.ModelViews
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task DisplayAlert(string message, string title = "", string acceptButton = "")
        {
            if (String.IsNullOrEmpty(title)) title = AppLanguage._Shared_Title;
            if (String.IsNullOrEmpty(acceptButton)) acceptButton = AppLanguage._Shared_OK;
            await Application.Current.MainPage.DisplayAlert(title, message, acceptButton);
        }

        private bool isBusy;
        public bool IsBusy 
        { 
            get=> isBusy; 
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    OnPropertyChanged();
                }
            } 
        }
    }
}
