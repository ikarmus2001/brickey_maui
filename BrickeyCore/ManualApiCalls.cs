using BrickeyCore.RebrickableModel;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BrickeyCore
{
    public abstract class ManualApiCalls
    {
        public static async Task<string> GetUserToken(string username, string password)
        {
            var userRequest = "users/_token/";

            var parameters = new Dictionary<string, string>()
            {
                {"username", username},
                {"password", password}
            };

            UserTokenResponse? userTokenResponse;
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
        }

        internal static async Task<UserProfile?> GetUserProfile()
        {
            var userRequest = $"users/{RebrickableApiWrapper._userToken}/profile/";
            string content = await GetData(userRequest);

            return JsonSerializer.Deserialize<UserProfile>(content);
        }

        internal static async Task<PagedResponse<Minifigure>> GetMinifigures(string search)
        {
            var userRequest = "lego/minifigs/?";
            var parameters = new Dictionary<string, string>()
            {
                {"search", search}
            };
            string content = await GetData(userRequest, parameters);

            PagedResponse<Minifigure>? minifiguresResponse = JsonSerializer.Deserialize<PagedResponse<Minifigure>>(content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return minifiguresResponse ?? throw new HttpRequestException("");
        }

        internal static async Task<PagedResponse<Set>> GetSets(string search)
        {
            var userRequest = "lego/sets/?";
            var parameters = new Dictionary<string, string>()
            {
                {"search", search}
            };
            string content = await GetData(userRequest, parameters);

            PagedResponse<Set>? minifiguresResponse = JsonSerializer.Deserialize<PagedResponse<Set>>(content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return minifiguresResponse ?? throw new HttpRequestException("");
        }

        internal static async Task<PagedResponse<Part>> GetParts(string search)
        {
            var userRequest = "lego/parts/?";
            var parameters = new Dictionary<string, string>()
            {
                {"search", search}
            };
            string content = await GetData(userRequest, parameters);

            PagedResponse<Part>? minifiguresResponse = JsonSerializer.Deserialize<PagedResponse<Part>>(content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return minifiguresResponse ?? throw new HttpRequestException("");
        }

        internal static async Task<PagedResponse<PartOfSet>> GetMinifigureParts(string mfId)
        {
            var userRequest = $"lego/minifigs/{mfId}/parts/";
            string content = await GetData(userRequest);

            PagedResponse<PartOfSet>? minifiguresResponse = null;
            try
            {
                minifiguresResponse = JsonSerializer.Deserialize<PagedResponse<PartOfSet>>(content, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (JsonException e)
            {
                throw e;
            }
            return minifiguresResponse ?? throw new HttpRequestException("");
        }

        internal static async Task<PartDetails> GetPartDetails(string partId)
        {
            var userRequest = $"lego/parts/{partId}/";
            string content = await GetData(userRequest);

            PartDetails? partResponse = JsonSerializer.Deserialize<PartDetails>(content, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return partResponse ?? throw new HttpRequestException("");
        }

        public static async Task<List<Set>> GetSetsDetails(string[] setIds)
        {
            string userRequest = $"lego/sets/";
            List<Set> setsResponse = new();
            foreach (string sId in setIds)
            {
                string content = await GetData($"{userRequest}/{sId}/");
                Set? setResponse = JsonSerializer.Deserialize<Set>(content, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                if (setResponse != null) setsResponse.Add(setResponse);
            }
            return setsResponse;
        }

        public static async Task<PagedResponse<PartOfSet>> GetSetsParts(string setId)
        {
            string userRequest = $"lego/sets/{setId}/parts/";

            string content = await GetData(userRequest);
            PagedResponse<PartOfSet>? response;
            try
            {
                response = JsonSerializer.Deserialize<PagedResponse<PartOfSet>>(content, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            catch (JsonException)
            {
                throw;
            }
            return response ?? throw new HttpRequestException();
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

            var request = new HttpRequestMessage(HttpMethod.Post, $"https://rebrickable.com/api/v3/{userRequest}");
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
