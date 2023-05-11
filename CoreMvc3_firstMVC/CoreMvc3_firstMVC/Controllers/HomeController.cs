using CoreMvc3_firstMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_firstMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            EventId eventId = new EventId(1234, "我的記錄資訊");
            _logger.LogTrace(eventId, "Logging - LogTrace()記錄資訊- Home/Index被呼叫");
            _logger.LogDebug(1234, "Logging - LogDebug()記錄資訊- Home/Index被呼叫");
            _logger.LogWarning(1234, "Logging - LogWarning()記錄資訊- Home/Index被呼叫");
            return View("IndexTest");
            //return View("~/Views/Home/IndexTest.cshtml");
            //return View("Views/Home/IndexTest.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
