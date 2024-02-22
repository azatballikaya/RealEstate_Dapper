using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultBottomGridViewComponentPartial:ViewComponent

    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBottomGridViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5067/api/BottomGrids");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultBottomGridDto>>(jsonData);
                return View(value);
            }
            return View(); 
        
        }
    }
}
