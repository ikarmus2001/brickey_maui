using BrickeyCore.RebrickableModel;
using System.Net.Http.Headers;

namespace BrickeyCore
{
    public abstract class RebrickableApiWrapper
    {
        private static string baseApiUrl = "https://rebrickable.com/api/v3/";
        private static string apiKey;
        private static HttpClient _httpClient;

        public static void Setup(string apiKey)
        {
            RebrickableApiWrapper.apiKey = apiKey;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseApiUrl)
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", apiKey);
            // TODO check connection?
        }

        public static async Task<UserProfile> GetUserProfile()
        {
            UserProfile? up = await ManualApiCalls.GetUserProfile(_httpClient);
            return up == null ? throw new Exception() : up;
        }
    }
}