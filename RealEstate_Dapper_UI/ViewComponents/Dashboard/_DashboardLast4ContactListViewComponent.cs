using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using RealEstate_Dapper_UI.Dtos.ContactDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardLast4ContactListViewComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLast4ContactListViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("http://localhost:5031/api/Contacts/GetLast4Contacts");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                    return View(values);
                }
                return View();
            
        }
    }
}
