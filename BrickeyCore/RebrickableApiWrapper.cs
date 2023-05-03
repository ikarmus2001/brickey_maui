using BrickeyCore.RebrickableModel;
using System.Net.Http.Headers;

namespace BrickeyCore
{
    public abstract class RebrickableApiWrapper
    {
        internal static string baseApiUrl = "https://rebrickable.com/api/v3/";
        internal static HttpClient _httpClient;
        internal static string apiKey;
        internal static string userToken;

        public static async Task<bool> Setup(string apiKey, string username, string password)
        {
            RebrickableApiWrapper.apiKey = apiKey;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseApiUrl)
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            userToken = await ManualApiCalls.GetUserToken(username, password);
            return true;
        }

        public static async Task<UserProfile> GetUserProfile()
        {
            UserProfile? up = await ManualApiCalls.GetUserProfile();
            return up ?? throw new Exception();
        }

        internal async static Task<List<Minifigure>> GetMinifigure(string searchQuery)
        {
            return ManualApiCalls.GetMinifigures(parameters);
        }
    }
}