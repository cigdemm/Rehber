using Rehber.DAL.KisiService;
using Rehber.Entities.Entities;
using Rehber.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rehber.MVC.Controllers
{
    public class AdresController : Controller
    {
        // GET: Adres

        AdresManager _adresManager;
        KisiManager _KisiManager;
        public AdresController()
        {
            _adresManager = new AdresManager();
            _KisiManager = new KisiManager();
        }


        //Kisileri getiren bir dropdown yapıp
        //Viewbag ile sayfama taşıma işlemi yapıcam
        public List<SelectListItem> DropdownDoldur() {

            List<SelectListItem> kisiListesi = (from p in _KisiManager.GetAllKisi().ToList()
                                                select new SelectListItem
                                                {
                                                    Text=p.Adi+" "+p.Soyadi,
                                                    Value=p.KisiID.ToString()
                                                }
                                               ).ToList();
            return kisiListesi;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AdresEkle()
        {
            ViewBag.KisiListesi=DropdownDoldur();
            return View();
        }

        [HttpPost]
        public ActionResult AdresEkle(AdresViewModel adresvm)
        {
            //Tempdata ile mesajı almak istersem;

            TempData["Message"] = _adresManager.AddAdres(new Adres {
                Il=adresvm.Il,
                Ilce=adresvm.Ilce,
                KisiID=adresvm.KisiId

            });
            return RedirectToAction("../Home/Index");

        }
        //Güncelleme işlemi için sayfaya verilerimi çekicek kısım
        [HttpGet]
        public ActionResult AdresGuncelle(int id)
        {
            ViewBag.KisiListesi = DropdownDoldur();
            var adres = _adresManager.GetAllAdres(x => x.AdresID == id);
            AdresViewModel adrsvm = new AdresViewModel
            {
                AdresID = adres.FirstOrDefault().AdresID,
                Il = adres.FirstOrDefault().Il,
                Ilce = adres.FirstOrDefault().Ilce,
                KisiId=adres.FirstOrDefault().KisiID

            };
   
            return View(adrsvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdresGuncelle(AdresViewModel adresvm)
        {
            Adres ad = new Adres
            {
                AdresID = adresvm.AdresID,
                Il = adresvm.Il,
                Ilce = adresvm.Ilce,
                KisiID = adresvm.KisiId
            };

            TempData["Message"] = _adresManager.UpdateAdres(ad);
            return RedirectToAction("../Home/Index");

        }
        [HttpGet]
        public ActionResult AdresSil(int id)
        {
            var adres = _adresManager.GetAllAdres(x=>x.AdresID==id);

            AdresViewModel ads = new AdresViewModel
            {
                AdresID = adres.FirstOrDefault().AdresID,
                Il = adres.FirstOrDefault().Il,
                Ilce = adres.FirstOrDefault().Ilce,
                KisiId = adres.FirstOrDefault().KisiID
            };
            var Kisi = _KisiManager.GetAllKisi(x => x.KisiID == ads.KisiId).FirstOrDefault();
            ViewBag.AdSoyad = Kisi.Adi + " " + Kisi.Soyadi;
            return View(ads);
        }
        [HttpPost]
        [ActionName("AdresSil")]
        public ActionResult AdresSilinsinMi(int id)
        {
            Adres adres = _adresManager.GetAllAdres(x => x.AdresID == id).FirstOrDefault();
            TempData["Message"] = _adresManager.DeleteAdres(adres);
            return RedirectToAction("../Home/Index");

        }











    }
}