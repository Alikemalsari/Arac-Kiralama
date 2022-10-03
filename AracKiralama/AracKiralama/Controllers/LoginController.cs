using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AracKiralama.Models;

namespace AracKiralama.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        AracKiralamaDBEntities db = new AracKiralamaDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login t)
        {
            var query = db.Logins.FirstOrDefault(x => x.KullaniciAdi == t.KullaniciAdi && x.Sifre == t.Sifre);
            if (query != null)
            {
                FormsAuthentication.SetAuthCookie(query.KullaniciAdi, false);
                ViewBag.hata = "";
                return RedirectToAction("Index", "Admin");
            }

            else
            {
                ViewBag.hata = "Kullanıcı adınız veya şifreniz hatalı";
                return View();
            }

        }

       

    }
}