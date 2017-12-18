using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
   
    public class SinemaController : Controller
    {
        public DateTime gun { get; set; }
        // GET: Sinema
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Guncel()
        {
            var sinemaListesi = new List<Etkinlik>();

            foreach (var sinema in EtkinlikRepository.ListeyiDoldur())
            {
                if ( sinema.EtkinlikTuru == EtkinlikTuru.Sinema)
                {
                    sinemaListesi.Add(sinema);
                }
            }

            //return View();
            //return View(sinemaListesi);
            return View("~/views/_shared/guncel.cshtml", sinemaListesi);
        }

        public ActionResult Tur(string tur)
        {
            var sinemaListesi = new List<Etkinlik>();

            foreach (var sinema in EtkinlikRepository.ListeyiDoldur())
            {
                if (sinema.AltTur == tur && sinema.EtkinlikTuru == EtkinlikTuru.Sinema)
                {

                    //if (!hepsimi && sinema.BitisTarihi<DateTime.Now)
                    //{
                    //    continue;
                    //}

                    sinemaListesi.Add(sinema);
                }
            }

            return View("~/views/_shared/guncel.cshtml", sinemaListesi);
        }

        public ActionResult Tarih(string tarih)
        {
            
            
            var sinemaListesi = new List<Etkinlik>();
            foreach (var sinema in EtkinlikRepository.ListeyiDoldur())
            {
                switch (tarih)
                {
                    case "bugün":
                        gun = DateTime.Now;
                        if (sinema.BitisTarihi <= gun && sinema.EtkinlikTuru == EtkinlikTuru.Sinema)
                        {
                            sinemaListesi.Add(sinema);
                        }
                        break;
                    case "buhafta":
                        gun = DateTime.Now.AddDays(7);
                        if (sinema.BitisTarihi <= gun && sinema.EtkinlikTuru == EtkinlikTuru.Sinema)
                        {
                            sinemaListesi.Add(sinema);
                        }
                        break;
                    case "buay":
                        gun = DateTime.Now.AddMonths(1);
                        if (sinema.BitisTarihi <= gun && sinema.EtkinlikTuru == EtkinlikTuru.Sinema)
                        {
                            sinemaListesi.Add(sinema);
                        }
                        break;
                }
                
            }
            return View("~/views/_shared/guncel.cshtml",sinemaListesi);
        }
    }
}