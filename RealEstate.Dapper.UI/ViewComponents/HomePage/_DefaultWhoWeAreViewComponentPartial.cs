using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultWhoWeAreViewComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5067/api/WhoWeAreDetail");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDto>>(jsonData).FirstOrDefault();
                var serviceResponseMessage = await client.GetAsync("http://localhost:5067/api/Services");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var serviceJsonData=await serviceResponseMessage.Content.ReadAsStringAsync();
                    var services=JsonConvert.DeserializeObject<List<ResultServiceDto>>(serviceJsonData);
                    value.Services = services;
                    return View(value);
                }

            }
            return View();
        }
    }
}
