using IdesseCaseStudy.Models;
using IdesseCaseStudy.Models.RequestModels;
using IdesseCaseStudy.Models.ResponseModels;
using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdesseCaseStudy.Services.AccountServices
{
    public interface IAccountService
    {
        [Post("/Account/Login")]
        Task<HttpResponseMessage> AccountLogin([Body()] LoginRequestModel login);

        Task<BaseResponseModel> Login([Body()] LoginRequestModel login);

        [Get("/Account/GetUserMobile")]
        Task<BaseResponseModel<User>> GetUserMobile([Header("Cookie")]string cookie = "");
    }
}
