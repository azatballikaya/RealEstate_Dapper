using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Areas.EstateAgent.Dtos.Dashboard;


namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.Dashboard
{
    public class _EstateAgentDashboardChartViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _EstateAgentDashboardChartViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5031/api/EstateAgentChart");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEstateAgentDashboardChartDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
