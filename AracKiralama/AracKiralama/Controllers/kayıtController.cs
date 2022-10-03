using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models;

namespace AracKiralama.Controllers
{
    public class kayıtController : Controller
    {
        // GET: kayıt
        AracKiralamaDBEntities db = new AracKiralamaDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kaydol(Login t)
        {
            var query = new Login()
            {
                KullaniciAdi = t.KullaniciAdi,
                Sifre = t.Sifre
            };
            db.Logins.Add(query);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
            

        }
    }
}