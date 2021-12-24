using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeS.Models
{
    public class AktifBilgisi
    {
        private string durumAd;

        private bool durumBilgisi;

        public string DurumAd { get => durumAd; set => durumAd = value; }
        public bool DurumBilgisi { get => durumBilgisi; set => durumBilgisi = value; }
    
}
}