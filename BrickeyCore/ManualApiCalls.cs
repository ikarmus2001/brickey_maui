using BrickeyCore.RebrickableModel;
using System.Net.Http;
using System.Text.Json;

namespace BrickeyCore
{
    public abstract class ManualApiCalls
    {
        public static async Task<UserProfile?> GetUserProfile(HttpClient httpClient)
        {
            var userRequest = $"/users/_token/";
            string content = await GetData(userRequest, httpClient);
            return JsonSerializer.Deserialize<UserProfile>(content);
        }

        private static async Task<string> GetData(string userRequest, HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.GetAsync(userRequest);

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
            //return x;
            return await response.Content.ReadAsStringAsync();
        }
    }
}
