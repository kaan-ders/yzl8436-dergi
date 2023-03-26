using DergiOrtak.Services;
using DergiOrtak.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DergiMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SayiController : Controller
    {
        private ISayiService _sayiService;
        private IDergiService _dergiService;
        public SayiController(ISayiService sayiService, IDergiService dergiService)
        {
            _sayiService = sayiService;
            _dergiService = dergiService;
        }

        public IActionResult Index(int id)
        {
            var liste = _sayiService.Listele(id);
            return View(liste);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.Dergiler = _dergiService.Listele();
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(SayiViewModel model)
        {
            if (ModelState.IsValid)
            {
                _sayiService.Ekle(model);
                return Redirect($"/Admin/Sayi/Index/{model.DergiId}");
            }
            else
                return View();
        }
    }
}
