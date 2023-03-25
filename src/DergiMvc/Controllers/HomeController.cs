using DergiMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DergiMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}