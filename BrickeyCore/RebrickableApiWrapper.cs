using BrickeyCore.RebrickableModel;
using RebrickableSharp.Client;
 using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace BrickeyCore
{
    public abstract class RebrickableApiWrapper
    {
        public static bool isConnected = false;
        private static IRebrickableClient? rebrickableClient;

        private static string baseApiUrl = "https://rebrickable.com/api/v3/";
        private static string apiKey = "";

        public static void Setup(string apiKey)
        {
            RebrickableApiWrapper.apiKey = apiKey;
            RebrickableClientConfiguration.Instance.ApiKey = apiKey;
            rebrickableClient = RebrickableClientFactory.Build();
            isConnected = true;
        }

        public static async Task<UserProfile> GetUserProfile()
        {
            string json = await RetrieveUserProfile();
            return JsonSerializer.Deserialize<UserProfile>(json);

        }

        /// <summary>
        /// Method is not present in RebrickableSharp, requires by hand implementation
        /// </summary>
        /// <returns></returns>
        
        private static async Task<string> RetrieveUserProfile()
        {
            var x = @"{
  ""user_id"": 851367,
  ""username"": ""mynick"",
  ""email"": ""whatev@gmail.com"",
  ""last_activity"": ""2023-04-16T11:56:53.926543Z"",
  ""last_ip"": ""1.1.1.1"",
  ""location"": null,
  ""rewards"": {
    ""points"": 15,
    ""level"": 2,
    ""badges"": [
      39
    ]
  },
  ""lego"": {
    ""total_sets"": 2,
    ""total_loose_parts"": 0,
    ""total_set_parts"": 700,
    ""lost_set_parts"": 0,
    ""all_parts"": 700,
    ""total_figs"": 2
  },
  ""avatar_img"": null
}";

            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseApiUrl)
            };

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("key", apiKey);
            var userRequest = $"/users/_token/";
            httpClient.GetAsync(userRequest);
            

            return x;
        }
        
        // TODO
        //public async Task CheckApiKey()
        //{
        //    //var secretsLocation = FileSystem.AppDataDirectory + "secrets.json";

        //    //if (!File.Exists(secretsLocation))
        //    //{
        //    //    CreateSecretsAppStorage();
        //    //    await AskForApiKey();
        //    //}
        //    //var apiKey = ReadApiKey().Result;  // TODO handle empty key
        //    //RebrickableApiWrapper.Setup(apiKey);
        //}

        //private void CreateSecretsAppStorage()
        //{
        //    //FileSystem.Current.
        //}

        //private async Task<string> ReadApiKey()
        //{
        //    //FileSystem.Current.OpenAppPackageFileAsync
        //}
    }
}