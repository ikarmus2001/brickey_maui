using BrickeyCore.RebrickableModel;
using System.Net.Http.Headers;

namespace BrickeyCore
{
    public abstract class RebrickableApiWrapper
    {
        private static string baseApiUrl = "https://rebrickable.com/api/v3/";
        internal static HttpClient _httpClient;
        private static string _apiKey;
        internal static string userToken;

        public static async Task<bool> Setup(string rebrickableApiKey, string username, string password)
        {
            RebrickableApiWrapper._apiKey = rebrickableApiKey;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseApiUrl)
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", _apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            userToken = await ManualApiCalls.GetUserToken(username, password);
            return true;
        }

        public static async Task<UserProfile> GetUserProfile()
        {
            UserProfile? up = await ManualApiCalls.GetUserProfile();
            return up ?? throw new Exception();
        }

        internal async static Task<PagedResponse<Minifigure>> GetMinifigures(string searchQuery)
        {
            return await ManualApiCalls.GetMinifigures(searchQuery);
        }

        internal async static Task<PagedResponse<Set>> GetSets(string searchQuery)
        {
            return await ManualApiCalls.GetSets(searchQuery);
        }

        internal async static Task<PagedResponse<Part>> GetParts(string searchQuery)
        {
            return await ManualApiCalls.GetParts(searchQuery);
        }

        public static async Task<PagedResponse<T>> RetrieveDatabaseInfo<T>(QueryModel qm)
        {
            PagedResponse<T> r = typeof(T) switch
            {
                Type mf when mf == typeof(Minifigure) => await GetMinifigures(qm.parameters["search"]),
                Type set when set == typeof(Set) => await GetSets(qm.parameters["search"]),
                Type part when part == typeof(Part) => (dynamic)await GetParts(qm.parameters["search"]),
                _ => null
            } ?? throw new InvalidOperationException();

            return r ?? throw new Exception();
        }

        public static async Task<PagedResponse<MinifigureParts>> GetMinifigureParts(string minifigId)
        {
            return await ManualApiCalls.GetMinifigureParts(minifigId) ?? throw new Exception();
        }
    }
}