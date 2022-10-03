using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using AracKiralama.Models;

namespace AracKiralama.Controllers
{
    public class AdminController : Controller
    {
        // GET: Anasayfa
        AracKiralamaDBEntities db = new AracKiralamaDBEntities();

        [Authorize]
        public ActionResult Index()
        {
            var query = db.AracBilgileris.ToList();

            return View(query);
        }

       
        public ActionResult Edit(int Id)
        {

            var entity = db.AracBilgileris.FirstOrDefault(x => x.Id == Id);


            AracBilgileriViewModel model = new AracBilgileriViewModel();
            model.Id = entity.Id;
            model.AracAdi = entity.AracAdi;
            model.AracBilgisi = entity.AracBilgisi;
            model.Fiyati = entity.Fiyati;
            model.AracResmi = entity.AracResmi;


            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AracBilgileriViewModel model, HttpPostedFileBase imgfile)
        {

            AracBilgileri arc = new AracBilgileri();
            string path = uploadimage(imgfile);
            if (path.Equals("-1"))
            {

            }
            else
            {
                var entity = db.AracBilgileris.FirstOrDefault(x => x.Id == model.Id);

                entity.AracAdi = model.AracAdi;
                entity.AracBilgisi = model.AracBilgisi;
                entity.Fiyati = model.Fiyati;
                entity.AracResmi = path;

                db.SaveChanges();



            }
            return RedirectToAction("Index", "Admin");




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
       
        public ActionResult Delete(int id)
        {

            var entity = db.AracBilgileris.FirstOrDefault(x => x.Id == id);

            db.AracBilgileris.Remove(entity);
            db.SaveChanges();

            return RedirectToAction("Index", "Anasayfa");

            //return Json(new { success = true, Message = "Kayıt Başarı ile silindi" }, JsonRequestBehavior.AllowGet);

        }

    }
}