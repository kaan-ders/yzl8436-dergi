using DergiOrtak.Services;
using DergiOrtak.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DergiMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MakaleController : Controller
    {
        private IDergiService _dergiService;
        private IMakaleService _makaleService;
        private ISayiService _sayiService;
        public MakaleController(IMakaleService makaleService, ISayiService sayiService, IDergiService dergiService)
        {
            _makaleService = makaleService;
            _sayiService = sayiService;
            _dergiService = dergiService;
        }

        public IActionResult Index(int id)
        {
            var liste = _makaleService.Listele(id);
            return View(liste);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            ViewBag.Dergiler = _dergiService.Listele();
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(MakaleViewModel model)
        {
            if(ModelState.IsValid)
            {
                _makaleService.Ekle(model);
                return Redirect("/Admin/Home/Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult SayiListele(int id)
        {
            return new JsonResult(_sayiService.Listele(id));
        }
    }
}