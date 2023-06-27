using IdesseCaseStudy.Models;
using IdesseCaseStudy.Models.RequestModels;
using IdesseCaseStudy.Models.ResponseModels;
using IdesseCaseStudy.Resources.Languages;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IdesseCaseStudy.Services.AccountServices
{
    public class AccountService : RefitManager<IAccountService>, IAccountService
    {
        public async Task<BaseResponseModel<User>> GetUserMobile([Header("Cookie")] string cookie)
        {
            try
            {
                var result = await _service.GetUserMobile(GetCookie());
                return result;
            }
            catch (Exception err)
            {
                await Application.Current.MainPage.DisplayAlert(AppLanguage._Shared_AppName, "GetUserMobile\n" + err.Message, AppLanguage._Shared_OK);
                return null;
            }
        }

        public async Task<HttpResponseMessage> AccountLogin([Body] LoginRequestModel login)
        {
            try
            {
                var result = await _service.AccountLogin(login);
                return result;
            }
            catch (Exception err)
            {
                await Application.Current.MainPage.DisplayAlert(AppLanguage._Shared_AppName, "AccountLogin\n" + err.Message, AppLanguage._Shared_OK);
                return null;
            }
        }

        public async Task<BaseResponseModel> Login(LoginRequestModel login)
        {
            try
            {
                var response = await AccountLogin(login);
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<BaseResponseModel>(response.Content.ReadAsStringAsync().Result);
                    if (response.Headers.Contains("Set-Cookie"))
                    {
                        if (response.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> setCookies))
                        {
                            string cookie = "";
                            foreach (var item in setCookies.OrderBy(x=> x))
                            {
                                cookie += (String.IsNullOrEmpty(cookie) ? "" : ";") + item.Split(';')[0];
                            }
                            SetCookie(cookie);
                        }
                    }
                    return result;
                }

                return null;
            }
            catch (Exception err)
            {
                await Application.Current.MainPage.DisplayAlert(AppLanguage._Shared_AppName, "Login\n" + err.Message, AppLanguage._Shared_OK);
                return null;
            }
        }
    }
}
