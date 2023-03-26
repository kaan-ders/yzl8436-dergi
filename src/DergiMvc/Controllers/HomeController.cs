using DergiOrtak.Services;
using Microsoft.AspNetCore.Mvc;

namespace DergiMvc.Controllers
{
    public class HomeController : Controller
    {
        private IDergiService _dergiService;
        private ISayiService _sayiService;
        private IMakaleService _makaleService;
        public HomeController(IDergiService dergiService, ISayiService sayiService, IMakaleService makaleService)
        {
            _dergiService = dergiService;
            _sayiService = sayiService;
            _makaleService = makaleService;
        }

        public IActionResult Index()
        {
            var liste = _dergiService.Listele();
            return View(liste);
        }

        public IActionResult Sayi(int id)
        {
            var liste = _sayiService.Listele(id);
            return View(liste);
        }

        public IActionResult Makaleler(int id)
        {
            var liste = _makaleService.Listele(id);
            return View(liste);
        }

        public IActionResult Makale(int id)
        {
            var makale = _makaleService.Getir(id);
            return View(makale);
        }
    }
}