using IdesseCaseStudy.Models.RequestModels;
using IdesseCaseStudy.Models.ResponseModels;
using Refit;
using System.Threading.Tasks;

namespace IdesseCaseStudy.Services.CardServices
{
    public interface ICardService
    {
        [Post("/Card/GetListMobile")]
        Task<CardGetListMobileResponseModel> GetListMobile([Body()] CardGetListMobileRequestModel request, [Header("Cookie")] string cookie = "");
    }
}
