﻿using Microsoft.AspNetCore.Mvc;

namespace PW.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
