using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace ProjeS.Controllers
{
    [AllowAnonymous]
    public class GirisController : Controller
    {
        // GET: Giris
        //Context c = new Context();
        ProjeS.Models.SinavİlanEntities2 c = new Models.SinavİlanEntities2();

     
        public ActionResult Index() 
        {
            return View();
        }

        [HttpPost]          
        public ActionResult AdminLogin(Models.Kullanicis p)             
        {
            var bilgiler = c.Kullanicis.FirstOrDefault(x => x.eposta == p.eposta && x.sifre == p.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.eposta, false);
                    
                Session["eposta"] = bilgiler.eposta.ToString();
                Session["yetki"] = bilgiler.yetki.ToString();


                return RedirectToAction("Index", "SinavIlan");


            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Giris");
        }
    }
}