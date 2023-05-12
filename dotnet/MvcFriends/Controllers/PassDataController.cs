using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcFriends.Models;

namespace MvcFriends.Controllers
{
    public class PassDataController : Controller
    {
        private readonly ILogger<PassDataController> _logger;

        public List<Employee> empsList { get; } = new List<Employee>
        {
            new Employee { Id = 10001, Name = "David", Phone = "0933-154228", Email ="david@gmail.com" },
            new Employee { Id = 10002, Name = "Mary", Phone = "0925-157886", Email ="mary@gmail.com" },
            new Employee { Id = 10003, Name = "John", Phone = "0921-335884", Email ="john@gmail.com" },
            new Employee { Id = 10004, Name = "Cindy", Phone = "0971-628322", Email ="cindy@gmail.com" },
            new Employee { Id = 10005, Name = "Rose", Phone = "0933-154228",  Email ="rose@gmail.com" }
        };

        public PassDataController(ILogger<PassDataController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PassViewData()
        {
            ViewData["Name"] = "Erwin";
            ViewData["Age"] = 21;
            ViewData["Single"] = true;
            ViewData["Employees"] = empsList;
            return View();
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
