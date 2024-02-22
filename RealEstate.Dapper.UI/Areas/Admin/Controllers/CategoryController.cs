using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Areas.Admin.Dtos.CategoryDtos;
using System.Text;


namespace RealEstate_Dapper_UI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5067/api/Categories");
            if (responseMessage.IsSuccessStatusCode) { 
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(value);
            }
            return View();
        }
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createCategoryDto);
            StringContent content= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5067/api/Categories", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(createCategoryDto);  
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5067/api/Categories/{id}");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5067/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(value);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateCategoryDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("http://localhost:5067/api/Categories",content);
            if (responseMessage.IsSuccessStatusCode)
            {
               return RedirectToAction("Index");
            }
            return View(updateCategoryDto);
        }
    }
}
