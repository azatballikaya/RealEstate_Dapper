using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.Dashboard
{
    [Area("EstateAgent")]
    public class _EstateAgentDashboardStatisticsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        public _EstateAgentDashboardStatisticsViewComponent(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            #region Statistics1 - Toplam İlan Sayısı
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("http://localhost:5031/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion
            #region Statistics2 - Emlakçının Toplam İlan Sayısı
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:5031/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId/"+id);
            var jsonData11 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeByProductCount = jsonData11;
            #endregion
            #region Statistics3 - Aktif İlan Sayısı
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:5031/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue/"+id);
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeByStatusTrue = jsonData3;
            #endregion
            #region Statistics4 - Pasif İlan Sayısı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("http://localhost:5031/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse/"+id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();

            ViewBag.productCountByEmployeeByStatusFalse = jsonData4;
            #endregion 
            return View();
        }
    }
}
