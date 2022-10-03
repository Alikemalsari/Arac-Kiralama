using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models;

namespace AracKiralama.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        AracKiralamaDBEntities db = new AracKiralamaDBEntities();
        
        public ActionResult Index()
        {
            var query = db.AracBilgileris.ToList();

            return View(query);
        }

        

    }
}