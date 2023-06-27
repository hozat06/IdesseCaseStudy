using Acr.UserDialogs;
using IdesseCaseStudy.Managers;
using IdesseCaseStudy.Models.RequestModels;
using IdesseCaseStudy.Pages;
using IdesseCaseStudy.Resources.Languages;
using IdesseCaseStudy.Services.AccountServices;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace IdesseCaseStudy.ModelViews
{
    public class AccountViewModel : BaseViewModel
    {
        private readonly IAccountService accountService;

        private LoginRequestModel loginRequest;
        public LoginRequestModel LoginRequest
        {
            get => loginRequest;
            set
            {
                if (loginRequest != null)
                {
                    loginRequest = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; private set; }

        private async Task LoginAsync()
        {
            if (String.IsNullOrEmpty(loginRequest.Username) || String.IsNullOrEmpty(loginRequest.Password))
            {
                ToastManager.Error(AppLanguage.LoginPage_LoginValidation);
                return;
            }

            using (var loading = UserDialogs.Instance.Loading())
            {
                await Task.Delay(10);
                loading.Title = AppLanguage._Shared_Loading;

                try
                {
                    var result = await accountService.Login(loginRequest);
                    if (result != null && result.Success)
                    {
                        var userResponse = await accountService.GetUserMobile();
                        if (userResponse != null && userResponse.Success)
                        {
                            App.CurrentUser = userResponse.Data;
                            Preferences.Set("user", JsonConvert.SerializeObject(userResponse.Data));
                            Application.Current.MainPage = new MenuPage();
                            ToastManager.Success(AppLanguage.LoginPage_LoginSuccessful);
                        }
                    }
                    else if (result != null && !result.Success)
                    {
                        ToastManager.Error(result.ErrorMsg);
                    }
                    else
                    {
                        ToastManager.Error(AppLanguage._Shared_Error);
                    }
                }
                catch (Exception err)
                {
                    await DisplayAlert("LoginAsync\n" + err.Message);
                }
            }
        }

        public AccountViewModel()
        {
            accountService = new AccountService();
            LoginCommand = new Command(async () => await LoginAsync());
            loginRequest = new LoginRequestModel("demo607", "1234567");
        }
    }
}
