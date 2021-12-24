using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeS.Models;


namespace ProjeS.Controllers
{
    public class SalonController : Controller
    {
        // GET: Salon
        ProjeS.Models.SinavİlanEntities2 c = new Models.SinavİlanEntities2();

        public ActionResult Index()
        {

            if (Convert.ToString(Session["yetki"]).Trim() == "var")
            {
                var degerler = c.Salons.ToList();
                return View(degerler);
            }
            return RedirectToAction("Index", "Anasayfa");
        }
        [HttpGet]
        public ActionResult SalonEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SalonEkle(Salons d)
        {

            Salons sln = new Salons();
            sln.salonAdi = d.salonAdi;
            c.Salons.Add(sln);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SalonSil(int id)
        {
            var sln = c.Salons.Find(id);
            c.Salons.Remove(sln);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult SalonGetir(int id)
        {
            var ders = c.Salons.Find(id);

            return View("SalonGetir", ders);
        }
        public ActionResult SalonGuncelle(Salons d)
        {
            var sln = c.Salons.Find(d.salonId);
            sln.salonAdi = d.salonAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}