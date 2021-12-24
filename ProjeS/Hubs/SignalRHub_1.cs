using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjeS.Models;

namespace ProjeS.Hubs
{
    [HubName("hubdata")]
    public class SignalRHub_1 : Hub
    {
        private static readonly System.Timers.Timer _timer = new System.Timers.Timer();
        static SignalRHub_1()
        {
            _timer.Interval = 5000;
            _timer.Elapsed += TimerElapsed;
            _timer.Start();
        }

        static void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<SignalRHub_1>();
            var data = new ViewModel.vmSinavIlan();
            using (SinavİlanEntities2 context = new SinavİlanEntities2())
            {
                DateTime trh = DateTime.Now.Date;
                // sisteme girdiğim gün için ilan var mı tarih bazında çektim
                var result = context.Sinavİlan.Where(p => p.tarih == trh).ToList();
                foreach (var item in result)
                {
                    //burada her kayıt için acaba sistem saatinden 15 dk geçti mi sistem saatinden 5 dakika once mi kontrolu var
                    var saat = context.Saats.FirstOrDefault(p => p.saatId == item.saatId);
                    string tarihsaat = item.tarih.ToShortDateString() + " " + saat.saat;
                    DateTime ilantarihsaat = Convert.ToDateTime(tarihsaat);
                    // 2 şartada uyacaksa listeye ekleyip geri döndürecez

                    TimeSpan fark = DateTime.Now.Subtract(ilantarihsaat);
                    if (fark.TotalMinutes >= -5 && fark.TotalMinutes < 16)
                    {
                        sinavilandata sinavilandata = new sinavilandata();
                        sinavilandata.dersAdi= item.Ders.DersAdi;
                        sinavilandata.salonAdi = item.Salons.salonAdi;
                        sinavilandata.bolumAdi= item.Ders.Bolums.BolumAdi;
                        sinavilandata.saat= item.Saats.saat;
                        sinavilandata.tarih= item.tarih.ToShortDateString();
                        sinavilandata.aciklama = item.aciklama;
                        data.sinavIlanListesi.Add(sinavilandata);
                    }
                }
            }

            hub.Clients.All.addData(data);
        }
    }
}