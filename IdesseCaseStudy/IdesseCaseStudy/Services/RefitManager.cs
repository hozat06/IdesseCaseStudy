using Newtonsoft.Json;
using Refit;
using Xamarin.Essentials;

namespace IdesseCaseStudy.Services
{
    public class RefitManager<TService>
    {
        private const string _apiUrl = "https://demo2.idesse.com";
        public TService _service;

        public string GetCookie() => Preferences.Get("Cookie", "");

        public void SetCookie(string cookie) => Preferences.Set("Cookie", cookie);



        public RefitManager()
        {
            NewtonsoftJsonContentSerializer settings = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            });

            _service = RestService.For<TService>(_apiUrl,
                new RefitSettings
                {
                    ContentSerializer = settings
                });
        }
    }
}
