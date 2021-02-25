using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ThirdPartyApi.Models;

namespace ThirdPartyApi.Services
{
    public class ApiService : IApiService
    {
        private static readonly HttpClient client;

        static ApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri("https://covid19-api.org")
            };
        }

        public async Task<List<PredictionModel>> GetPredictions()
        {
            // Building the URL of covid API
            var url = string.Format("/api/prediction/SE");

            var result = new List<PredictionModel>();

            // Making an API call using the GetAsync method that sends a GET Request to add the...
            // ...specified Uri as an asynchronous operation
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                // ReadAsStringAsync method serializes the HTTP content to a string
                var stringResponse = await response.Content.ReadAsStringAsync();

                //JsonSerializer to Deserialize the JSON response string into a List of PredictionModel objects.
                result = JsonSerializer.Deserialize<List<PredictionModel>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;

        }
    }
}
