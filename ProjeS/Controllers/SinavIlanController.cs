using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeS.Models;

namespace ProjeS.Controllers
{
    public class SinavIlanController : Controller
    {
        // GET: SinavIlan

        ProjeS.Models.SinavİlanEntities2 c = new Models.SinavİlanEntities2();

        public ActionResult Index()
        {
            //List<Bolums> bolumler = c.Bolums.ToList();
            //ViewBag.bolumler = new SelectList(bolumler, "BolumId", "BolumAdi");




            var degerler = c.Sinavİlan.ToList();
            return View(degerler);







            List<SelectListItem> deger1 = (from x in c.Ders.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DersAdi,
                                               Value = x.DersId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;


        }
        //public JsonResult GetStateList(int BolumId)
        //{
        //    c.Configuration.ProxyCreationEnabled = false;
        //    List<Ders> StateList = c.Ders.Where(x => x.BolumId == BolumId).ToList();
        //    return Json(StateList, JsonRequestBehavior.AllowGet);

        //}


        [HttpGet]
        public ActionResult IlanEkle()
        {
            List<SelectListItem> deger3 = (from x in c.Saats.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.saat,
                                               Value = x.saatId.ToString()
                                           }).ToList();

            ViewBag.dgr3 = deger3;

            List<SelectListItem> deger2 = (from x in c.Bolums.Where(p => p.aktiflik == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.BolumAdi,
                                               Value = x.BolumId.ToString(),


                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger4 = (from x in c.Ders.Where(p => p.aktiflik == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DersAdi,
                                               Value = x.DersId.ToString()
                                           }).ToList();
            ViewBag.dgr4 = deger4;

            List<SelectListItem> deger5 = (from x in c.Salons.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.salonAdi,
                                               Value = x.salonId.ToString()
                                           }).ToList();
            ViewBag.dgr5 = deger5;
            return View();
        }
        [HttpPost]
        public ActionResult IlanEkle(Sinavİlan sl)
        {
            Sinavİlan sinav = new Sinavİlan();
            // sinav.Ders.BolumId = sl.Ders.BolumId;
            sinav.DersId = sl.DersId;
            sinav.bolumID = sl.bolumID;
            sinav.salonId = sl.salonId;
            sinav.tarih = sl.tarih;
            sinav.saatId = sl.saatId;
            sinav.aciklama = sl.aciklama;
            c.Sinavİlan.Add(sinav);
            c.SaveChanges();
            //return View("Index");
            return RedirectToAction("Index");
        }
        public ActionResult IlanSil(int id)
        {
            var sln = c.Sinavİlan.Find(id);
            c.Sinavİlan.Remove(sln);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult IlanGuncelle(int id)
        {
            var sln = c.Sinavİlan.Find(id);

            return View("IlanGuncelle", sln);
        }
        public ActionResult IlanGuncelle_gelen(Sinavİlan nesne)
        {
            var edit = c.Sinavİlan.Find(nesne.SinavIlanNo);
            edit.DersId = nesne.DersId;
            edit.salonId = nesne.sinifId;
            edit.saatId = nesne.saatId;
            edit.tarih = nesne.tarih;
            edit.aciklama = nesne.aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        public JsonResult altKateGetir(int p)
        {
            var altKategoriler = (from x in c.Ders
                                  join y in c.Bolums on x.BolumId equals y.BolumId
                                  where x.BolumId == p
                                  select new
                                  {
                                      Text = x.DersAdi,
                                      Value = x.BolumId.ToString()
                                  }).ToList();
            return Json(altKategoriler, JsonRequestBehavior.AllowGet);
        }





        //[HttpPost]
        //public JsonResult derslist(int id)
        //{
        //    List<Ders> dersliste = c.Ders.Where(f => f.BolumId == id).OrderBy(f => f.DersAdi).ToList();
        //    List<SelectListItem> itemlist = (from i in dersliste
        //                                     select new SelectListItem
        //                                     {
        //                                         Value = i.DersId.ToString(),
        //                                         Text =i.DersAdi

        //                                     }).ToList();


        //    return Json(itemlist, JsonRequestBehavior.AllowGet);

        //}


    }
}