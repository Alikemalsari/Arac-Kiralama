using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models;

namespace AracKiralama.Controllers
{
    public class AracKayitController : Controller
    {
       
        // GET: AracKayit
        AracKiralamaDBEntities db = new AracKiralamaDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult AracKayitMethod(AracBilgileri t)
        //{

        //    var query = new AracBilgileri()
        //    {
        //        AracAdi = t.AracAdi,
        //        AracBilgisi = t.AracBilgisi,
        //        Fiyati = t.Fiyati,
        //        AracResmi = t.AracResmi
        //    };
        //    db.AracBilgileris.Add(query);
        //    db.SaveChanges();
        //    return RedirectToAction("Index", "AracKayit");


        //}

        [HttpPost]
        public ActionResult AracKayitMethod(AracBilgileri t, HttpPostedFileBase imgfile)
        {

            AracBilgileri arc = new AracBilgileri();
            string path = uploadimage(imgfile);
            if (path.Equals("-1"))
            {

            }
            else
            {
                arc.AracAdi = t.AracAdi;
                arc.AracBilgisi = t.AracBilgisi;
                arc.AracResmi = path;
                arc.Fiyati = t.Fiyati;
                db.AracBilgileris.Add(arc);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "AracKayit");

        }

        public string uploadimage(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                    }
                    catch (Exception ex)
                    {

                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<Script>alert('Only jpg,jpeg or png formats are acceptable....');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('please select a file');</script>");
                path = "-1";
            }
            return path;
        }
    }
}