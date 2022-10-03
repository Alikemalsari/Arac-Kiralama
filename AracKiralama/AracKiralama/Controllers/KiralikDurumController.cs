using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models;

namespace AracKiralama.Controllers
{
    public class KiralikDurumController : Controller
    {
        // GET: KiralikDurum
        AracKiralamaDBEntities db = new AracKiralamaDBEntities();
        public ActionResult Index()
        {
            var query = db.Kiralayans.ToList();


            
            return View(query);
        }
    }
}