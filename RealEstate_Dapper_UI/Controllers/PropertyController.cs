using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailsDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5031/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5031/api/Products/GetProductById/"+id);
            var responseMessage2 = await client.GetAsync("http://localhost:5031/api/ProductDetails?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsonData2=await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultProductWithCategoryDto>(jsonData);
                var values2 = JsonConvert.DeserializeObject<ResultProductDetailsDto>(jsonData2);
                ViewBag.Id = values.ProductId;
                ViewBag.Title = values.Title;
                ViewBag.Price = values.Price;
                ViewBag.City = values.District;
                ViewBag.Address = values.Address;
                ViewBag.Type = values.Type;
                ViewBag.Description = values.Description;
                ViewBag.AdvertiesmentDate = values.AdvertiesmentDate.ToShortDateString();
                ViewBag.DateDiff =(DateTime.Now -values.AdvertiesmentDate).Days /30;

                ViewBag.BathCount = values2.BathCount;
                ViewBag.BedCount = values2.BedRoomCount;
                ViewBag.Size = values2.ProductSize;
                ViewBag.GarageSize = values2.GarageSize;
                ViewBag.BuildYear = values2.BuildYear;

                return View();
            }
            return View();
            
        }
    }
}
