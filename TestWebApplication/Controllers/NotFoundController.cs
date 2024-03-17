using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class NotFoundController : Controller
    {
        public IActionResult UsersNotFound()
        {
            return View("UsersNotFound");
        }
        
    }
}
