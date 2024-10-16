using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using RealEstate_Dapper_Api.Repositories.StatisticRepository;
using System.Text.Json.Serialization;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IStatisticRepository _statisticRepository;
        public SignalRHub(IHttpClientFactory httpClientFactory, IStatisticRepository statisticRepository)
        {
            _httpClientFactory = httpClientFactory;
            _statisticRepository = statisticRepository;
        }
        public async Task SendCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5031/api/Statistics/CategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();

            await Clients.All.SendAsync("ReceiveCategoryCount",jsonData);
        }
    }
}
