using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjeS.Models;




namespace ProjeS.Controllers
{
    public class IlanWebController : Controller
    {
        // GET: IlanWeb
        ProjeS.Models.SinavİlanEntities2 c = new Models.SinavİlanEntities2
            ();

        public ActionResult Index()
        {
            ViewModel.vmSinavIlan model = new ViewModel.vmSinavIlan();
            return View(model);
          
        }
    }
}