using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFriends.Controllers
{
    public class ErrorHandlerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ErrorMessage()
        {
            if (!TempData.ContainsKey("ErrorMessage"))
            {
                return new EmptyResult();
            }

            //TempData.Keep();  //保留全部Key
            TempData.Keep("ErrorMessage");    //保留指定Key,若重新更新ErrorMessage.cshtml，只有ErrorMessage被保留(即儲存在Session中)

            return View();
        }
    }
}
