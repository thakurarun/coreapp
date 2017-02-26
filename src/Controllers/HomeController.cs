using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Database.Entities;
using Database.Repository;

namespace src.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {
        
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
