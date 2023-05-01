using BrickeyCore.RebrickableModel;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BrickeyCore
{
    public abstract class ManualApiCalls
    {
        public static async Task<string> GetUserToken(string username, string password)
        {
            var userRequest = $"users/_token/";

            var parameters = new Dictionary<string, string>()
            {
                {"username", username},
                {"password", password}
            };

            UserTokenResponse userTokenResponse;
            string content = await PostData(userRequest, parameters);
            try
            {
                userTokenResponse = JsonSerializer.Deserialize<UserTokenResponse>(content, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (Exception e)
            {
                var _ = e.Message;
                throw;
            }
            return userTokenResponse == null ? throw new HttpRequestException("") : userTokenResponse.user_token;

            /* Sample request
            //            var x = @"{
            //  ""user_id"": 851367,
            //  ""username"": ""mynick"",
            //  ""email"": ""whatev@gmail.com"",
            //  ""last_activity"": ""2023-04-16T11:56:53.926543Z"",
            //  ""last_ip"": ""1.1.1.1"",
            //  ""location"": null,
            //  ""rewards"": {
            //    ""points"": 15,
            //    ""level"": 2,
            //    ""badges"": [
            //      39
            //    ]
            //  },
            //  ""lego"": {
            //    ""total_sets"": 2,
            //    ""total_loose_parts"": 0,
            //    ""total_set_parts"": 700,
            //    ""lost_set_parts"": 0,
            //    ""all_parts"": 700,
            //    ""total_figs"": 2
            //  },
            //  ""avatar_img"": null
            //}";
            //return x;
            */
        }

        internal static async Task<UserProfile?> GetUserProfile()
        {
            var userRequest = $"users/{RebrickableApiWrapper.userToken}/profile/";
            string content = await GetData(userRequest);

            return JsonSerializer.Deserialize<UserProfile>(content);
        }

        private static async Task<string> PostData(string userRequest, Dictionary<string, string> parameteres)
        {
            if (parameteres.Count <= 0)
            {
                throw new ArgumentException("No parameters passed");
            }

            string content = "";
            foreach (KeyValuePair<string, string> p in parameteres)
            {
                content += $"&{p.Key}={p.Value}";
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "https://rebrickable.com/api/v3/users/_token/");
            request.Content = new StringContent(content);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            HttpResponseMessage response = await RebrickableApiWrapper._httpClient.SendAsync(request);
            return await response.Content.ReadAsStringAsync();
        }

        private static async Task<string> GetData(string userRequest, Dictionary<string, string>? parameteres = null)
        {
            if (parameteres != null && parameteres.Count > 0)
            {
                foreach (KeyValuePair<string, string> p in parameteres)
                {
                    userRequest += $"{p.Key}={p.Value}&";
                }
                userRequest = userRequest.Remove(userRequest.Length - 1);
            }

            HttpResponseMessage response = await RebrickableApiWrapper._httpClient.GetAsync(userRequest);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
