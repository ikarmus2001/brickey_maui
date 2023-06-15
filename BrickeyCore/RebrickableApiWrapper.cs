using System.Collections.ObjectModel;
using BrickeyCore.RebrickableModel;
using System.Net.Http.Headers;

namespace BrickeyCore
{
    public abstract class RebrickableApiWrapper
    {
        private static string baseApiUrl = "https://rebrickable.com/api/v3/";
        private static string _apiKey;
        internal static HttpClient _httpClient;
        internal static string _userToken;

        
        public static async Task<bool> Setup(string rebrickableApiKey, string username, string password)
        {
            _apiKey = rebrickableApiKey;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseApiUrl)
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", _apiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _userToken = await ManualApiCalls.GetUserToken(username, password);
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<UserProfile> GetUserProfile()
        {
            UserProfile? up = await ManualApiCalls.GetUserProfile();
            return up ?? throw new Exception();
        }

        private static async Task<PagedResponse<Minifigure>> GetMinifigures(string searchQuery)
        {
            return await ManualApiCalls.GetMinifigures(searchQuery);
        }

        private static async Task<PagedResponse<Set>> GetSets(string searchQuery)
        {
            return await ManualApiCalls.GetSets(searchQuery);
        }

        private static async Task<PagedResponse<Part>> GetParts(string searchQuery)
        {
            return await ManualApiCalls.GetParts(searchQuery);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="qm"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
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

        public static async Task<PagedResponse<PartOfSet>> GetMinifigureParts(string minifigId)
        {
            return await ManualApiCalls.GetMinifigureParts(minifigId) ?? throw new Exception();
        }

        public static async Task<PartDetails> GetPartDetails(string partId)
        {
            return await ManualApiCalls.GetPartDetails(partId);
        }

        public static async Task<List<Set>> GetSetsDetails(string[] setIds)
        {
            return await ManualApiCalls.GetSetsDetails(setIds);
        }

        public static async Task<PagedResponse<PartOfSet>> GetSetsParts(string setId)
        {
            return await ManualApiCalls.GetSetsParts(setId);
        }
    }
}