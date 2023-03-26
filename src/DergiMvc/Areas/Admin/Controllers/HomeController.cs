using DergiOrtak.Services;
using DergiOrtak.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DergiMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private IDergiService _dergiService;
        public HomeController(IDergiService dergiService, SignInManager<IdentityUser> signInManager)
        {
            _dergiService = dergiService;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var liste = _dergiService.Listele();
            return View(liste);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = _dergiService.KategorileriListele();
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(DergiViewModel model)
        {
            if (ModelState.IsValid)
            {
                _dergiService.DergiEkle(model);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}