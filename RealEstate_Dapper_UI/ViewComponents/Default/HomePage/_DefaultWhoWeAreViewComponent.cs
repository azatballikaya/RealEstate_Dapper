using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Default.HomePage
{
    public class _DefaultWhoWeAreViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultWhoWeAreViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5031/api/WhoWeAreDetails");
            var responseMessage2 = await client.GetAsync("http://localhost:5031/api/Services");
            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var jsonData2=await responseMessage2.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultWhoWeAreDto>>(jsonData);
                var values2=JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);
                var firstData=values.FirstOrDefault();
                ViewBag.title = firstData.Title;
                ViewBag.subtitle = firstData.Subtitle;
                ViewBag.description1 = firstData.Description1;
                ViewBag.description2 = firstData.Description2;
                return View(values2);
            }
            return View();
        }
    }
}
