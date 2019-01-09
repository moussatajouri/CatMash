using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CatMash.WebMVC.Domain;
using CatMash.WebMVC.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CatMash.WebMVC.Business
{
    public class CatService : ICatService
    {
        private HttpClient _httpClient;
        private readonly IOptions<ApiConfiguration> _apiConfiguration;

        public CatService(HttpClient httpClient, IOptions<ApiConfiguration> apiConfiguration)
        {
            _httpClient = httpClient;
            _apiConfiguration = apiConfiguration;
        }

        public async Task<CatScoresModel> GetCatScores()
        {
            var uri = $"{_apiConfiguration.Value.CatApiPath}/scores";
            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                return new CatScoresModel { Cats = new List<Cat>() };
            }

            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CatScoresModel>(content);
        }

        public async Task<Tuple<Cat, Cat>> GetCatsForVote()
        {
            var uri = $"{_apiConfiguration.Value.CatApiPath}/candidates";
            var response = await _httpClient.GetAsync(uri);
            
            var content = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Tuple<Cat, Cat>>(content);
        }

        public async Task SendVote(VoteModel vote)
        {
            var uri = $"{_apiConfiguration.Value.CatApiPath}/vote";

            var content = new StringContent(JsonConvert.SerializeObject(vote), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);


            response.EnsureSuccessStatusCode();
        }
    }
}
