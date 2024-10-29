using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Net.Http;

namespace RealEstate_Dapper_UI.ViewComponents.Default.HomePage
{
    public class _DefaultFeatureViewComponent:ViewComponent
    {
       

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return View();
        }
    }
}
