﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Default.HomePage
{
    public class _DefaultDiscountOfDayViewComponent:ViewComponent

    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
