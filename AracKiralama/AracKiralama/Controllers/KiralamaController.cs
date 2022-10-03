using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models;

namespace AracKiralama.Controllers
{
    public class KiralamaController : Controller
    {
        // GET: Kiralama
        AracKiralamaDBEntities db = new AracKiralamaDBEntities();
        public ActionResult Index(int id)
        {
            var entity = db.AracBilgileris.FirstOrDefault(x => x.Id == id);
            AracBilgileriViewModel model = new AracBilgileriViewModel();
            model.AracAdi = entity.AracAdi;
            model.AracBilgisi = entity.AracBilgisi;
            return View(model);

        }

        [HttpPost]
        public ActionResult Index(KiralayanViewModel t,int id)
        {
            var entity = db.AracBilgileris.FirstOrDefault(x => x.Id == id);

            var save = new Kiralayan()
            {
                IsimSoyisim = t.IsimSoyisim,
                Adres = t.Adres,
                TCKN = t.TCKN,
                Tel1 = t.Tel1,
                Tel2 = t.Tel2,
                EMail = t.EMail,
                KiralayacagiArac = entity.AracAdi
            };

            db.Kiralayans.Add(save);
            db.SaveChanges();
            return RedirectToAction("Index", "Anasayfa");
           

        }
    }
}