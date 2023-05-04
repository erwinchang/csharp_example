using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace CoreMvc3_firstMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public ProductsController(IWebHostEnvironment env)
        {
            _env = env;
            string contentRoot = env.ContentRootPath;
        }
        public IActionResult Index()
        {
            ViewData["EnvName"] = _env.EnvironmentName;
            ViewData["contentRoot"] = _env.ContentRootPath;
            return View();
        }
    }
}
