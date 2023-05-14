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
            PagedResponse<T> r = null;
            switch (typeof(T))
            {
                case Type mf when mf == typeof(Minifigure):
                    r = (dynamic)await GetMinifigures(qm.parameters["search"]);
                    break;
                case Type set when set == typeof(Set):
                    r = (dynamic)await GetSets(qm.parameters["search"]);
                    break;
                case Type part when part == typeof(Part):
                    r = (dynamic)await GetParts(qm.parameters["search"]);
                    break;

            }


            return r ?? throw new Exception();
        }

        public static async Task<PagedResponse<MinifigureParts>> GetMinifigureParts(string minifigId)
        {
            return await ManualApiCalls.GetMinifigureParts(minifigId) ?? throw new Exception();
        }
    }
}