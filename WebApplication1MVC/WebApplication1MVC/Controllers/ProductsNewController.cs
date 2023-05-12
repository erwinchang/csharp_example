using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1MVC.Controllers
{
    public class ProductsNewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ProductDetails()
        {
            return View();
        }
    }
}
