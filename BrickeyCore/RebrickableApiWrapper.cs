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
            PagedResponse<Minifigure> x = await ManualApiCalls.GetMinifigures(searchQuery);
            return x;
        }

        public static async Task<PagedResponse<T>> RetrieveDatabaseInfo<T>(QueryModel qm)
        {
            PagedResponse<T> r;
            switch (typeof(T))
            {
                case Type mf when mf == typeof(Minifigure):
                    r = (dynamic)await GetMinifigures(qm.parameters["search"]);
                    return r;
            }

            //        switch (qm.queryType)
            //{
            //    case QueryModel.QueryType.MiniFigure:
            //        PagedResponse<Minifigure> r = await GetMinifigures(qm.parameters["search"]);
            //        return r;
            //    case QueryModel.QueryType.Set:
            //        //PagedResponse<Set> r = await GetSets(qm.parameters["search"]);
            //        //return (PagedResponse<T>)(object)r;
            //    case QueryModel.QueryType.Part:
            //        //PagedResponse<Part> r = await GetParts(qm.parameters["search"]);
            //        //return (PagedResponse<T>)(object)r;
            //        break;
            //}
            return new PagedResponse<T>();
        }
    }
}