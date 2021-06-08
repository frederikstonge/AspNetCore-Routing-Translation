﻿using System.Globalization;
using System.Linq;
using AspNetCore.Routing.Translation.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCore.Routing.Translation.Controllers
{
    public sealed class RedirectController : Controller
    {
        private readonly RoutingTranslationOptions _options;
        
        public RedirectController(IOptions<RoutingTranslationOptions> options)
        {
            _options = options.Value;
        }
        
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            var rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = rqf.RequestCulture.Culture;
            
            var currentCulture = _options.SupportedCultures
                                     .FirstOrDefault(c => new CultureInfo(c).Equals(culture))
                                 ?? _options.DefaultCulture;
            
            return Redirect($"/{currentCulture}/");
        }
    }
}