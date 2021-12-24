using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeS.Models;

namespace ProjeS.Controllers
{
    public class BolumController : Controller
    {
        // GET: Bolum
        ProjeS.Models.SinavİlanEntities2 c = new Models.SinavİlanEntities2();

        public ActionResult Index()
        {
            if (Convert.ToString(Session["yetki"]).Trim() == "var")
            {
                var degerler = c.Bolums.Where(x => x.aktiflik == true).ToList();
             
                return View(degerler);
            }
            return RedirectToAction("Index", "Anasayfa");
        }
        [HttpGet]
        public ActionResult BolumEkle()
        {

            List<SelectListItem> Provinces = new List<SelectListItem>();
            Provinces.Add(new SelectListItem() { Text = "Aktif", Value = "true" });
            Provinces.Add(new SelectListItem() { Text = "Pasif", Value = "false" });

            ViewBag.AktiflikBilgisi = Provinces;

            return View();
        }
        [HttpPost]
        public ActionResult BolumEkle(Bolums d)
        {

            Bolums blm = new Bolums();
            blm.BolumAdi = d.BolumAdi;
            blm.aktiflik = d.aktiflik;
            c.Bolums.Add(blm);

            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult BolumSil(int id)
        {
            var blm = c.Bolums.Where(x => x.BolumId == id).First();
            blm.aktiflik = false;

            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult BolumGetir(int id)
        {
            List<SelectListItem> deger2 = (from x in c.Bolums.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BolumAdi,
                                               Value = x.BolumId.ToString()
                                           }).ToList();
            List<SelectListItem> Provinces = new List<SelectListItem>();
            Provinces.Add(new SelectListItem() { Text = "Aktif", Value = "true" });
            Provinces.Add(new SelectListItem() { Text = "Pasif", Value = "false" });
            ViewBag.dgr2 = deger2;
            ViewBag.AktiflikBilgisi = Provinces;
            var bolum = c.Bolums.Find(id);

            return View("BolumGetir", bolum);

        }
        public ActionResult BolumGuncelle(Bolums b)
        {
            var blm = c.Bolums.Find(b.BolumId);
            blm.BolumAdi = b.BolumAdi;
            blm.aktiflik = b.aktiflik;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}