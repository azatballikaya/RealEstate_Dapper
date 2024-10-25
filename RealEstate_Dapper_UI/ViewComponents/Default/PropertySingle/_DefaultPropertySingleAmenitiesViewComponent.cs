using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUserDtos;
using RealEstate_Dapper_UI.Dtos.PropertyAmenityDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Default.PropertySingle
{
    public class _DefaultPropertySingleAmenitiesViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultPropertySingleAmenitiesViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5031/api/PropertyAmenities/PropertyAmenitiesStatusPropertyId/1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPropertyAmenityStatusDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
