using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Admin.Layout
{
    public class _AdminLayoutSpinnerViewComponent:ViewComponent

    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
