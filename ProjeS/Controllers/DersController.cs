using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ProjeS.Models;
using System.Net;

namespace ProjeS.Controllers
{
    public class DersController : Controller
    {
        // GET: Ders
    ProjeS.Models.SinavİlanEntities2 c = new Models.SinavİlanEntities2();
        public ActionResult Index()

        {
           // List<Ders> dersliste = c.Ders.Where(x => x.aktiflik==true).ToList();

            if (Convert.ToString(Session["yetki"]).Trim() == "var")
            {

                List<Ders> dersliste = c.Ders.Where(x => x.aktiflik == true).ToList();


                return View(dersliste);
            }
            return RedirectToAction("Index", "Anasayfa");
        }
        [HttpGet]
        public ActionResult DersEkle()
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


            return View();
        }
        [HttpPost]
        public ActionResult DersEkle(Ders ders)


        {
            Ders yeniders = new Ders();
            yeniders.DersAdi = ders.DersAdi;
            yeniders.BolumId = ders.BolumId;
            yeniders.aktiflik = ders.aktiflik;
            c.Ders.Add(yeniders);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DersSil(int id)
        {
            var drs = c.Ders.Where(x => x.DersId == id).First();
            drs.aktiflik = false;
            
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
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

            var ders = c.Ders.Find(id);

            return View("DersGetir", ders);
        }
        public ActionResult DersGuncelle(Ders d, Bolums k)
        {

            var getir = c.Ders.Find(d.DersId);
            getir.DersAdi = d.DersAdi;
            getir.BolumId = d.BolumId;
            getir.aktiflik = d.aktiflik;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}