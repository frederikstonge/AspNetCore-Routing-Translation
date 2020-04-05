﻿using Microsoft.AspNetCore.Mvc;
using Randstad.Solutions.AspNetCoreRouting.Attributes;

namespace MvcApp.Controllers
{
    [Translate("en", "home")]
    [Translate("fr", "accueil")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}