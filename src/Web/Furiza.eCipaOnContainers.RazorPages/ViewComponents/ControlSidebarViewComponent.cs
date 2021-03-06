﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.RazorPages.ViewComponents
{
    public class ControlSidebarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.Delay(1);
            return View();
        }
    }
}