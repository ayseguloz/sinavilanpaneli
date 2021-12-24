using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjeS.Models;

namespace ProjeS.ViewModel
{
    public class vmSinavIlan
    {
        public vmSinavIlan()
        {
            sinavIlanListesi = new List<sinavilandata>();
        }
        public List<sinavilandata> sinavIlanListesi { get; set; }
    }
}

public class sinavilandata
{
    public string bolumAdi { get; set; }
    public string dersAdi { get; set; }
    public string salonAdi { get; set; }
    public string tarih { get; set; }
    public string saat { get; set; }

    public string aciklama { get; set; }

}