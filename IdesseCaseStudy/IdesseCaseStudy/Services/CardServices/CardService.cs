using IdesseCaseStudy.Models.RequestModels;
using IdesseCaseStudy.Models.ResponseModels;
using IdesseCaseStudy.Resources.Languages;
using Refit;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IdesseCaseStudy.Services.CardServices
{
    public class CardService : RefitManager<ICardService>, ICardService
    {
        public async Task<CardGetListMobileResponseModel> GetListMobile([Body] CardGetListMobileRequestModel request, [Header("Cookie")] string cookie)
        {
            try
            {
                var result = await _service.GetListMobile(request, GetCookie());
                return result;
            }
            catch (Exception err)
            {
                await Application.Current.MainPage.DisplayAlert(AppLanguage._Shared_AppName, "GetListMobile\n" + err.Message, AppLanguage._Shared_OK);
                return null;
            }
        }
    }
}
