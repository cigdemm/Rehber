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
    public class KisiController : Controller
    {
        KisiManager _kisiManager;
        public KisiController()
        {
            _kisiManager = new KisiManager();
        }

        [HttpGet]
        public ActionResult KisiEkle()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KisiEkle(KisiViewModel kisiVM)
        {
            string mesaj = _kisiManager.AddKisi(new Kisi { Adi = kisiVM.Adi, Soyadi = kisiVM.Soyadi, Yas = kisiVM.Yas });
            TempData["Message"] = mesaj;
            return RedirectToAction("../Home/Index");
        } // GET: Kisi
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult KisiGuncelle(int id)
        {
            Kisi kisi = _kisiManager.GetAllKisi(x => x.KisiID == id).FirstOrDefault();
            KisiViewModel model = new KisiViewModel
            {
                KisiId = kisi.KisiID,
                Adi = kisi.Adi,
                Soyadi = kisi.Soyadi,
                Yas = kisi.Yas
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KisiGuncelle(KisiViewModel kisiVM)
        {
            TempData["Message"] = _kisiManager.UpdateKisi(new Kisi { KisiID = kisiVM.KisiId, Adi = kisiVM.Adi, Soyadi = kisiVM.Soyadi, Yas = kisiVM.Yas });
            return RedirectToAction("../Home/Index");
        }

        [HttpGet]
        public ActionResult KisiSil(int id)
        {
            Kisi kisi = _kisiManager.GetAllKisi(x => x.KisiID == id).FirstOrDefault();

            TempData["Message"] = kisi.Adi + " " + kisi.Soyadi + " adlı kişiyi silmek istediğinize emin misiniz?";

            KisiViewModel model = new KisiViewModel
            {
                KisiId = kisi.KisiID,
                Adi = kisi.Adi,
                Soyadi = kisi.Soyadi,
                Yas = kisi.Yas
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("KisiSil")]
        public ActionResult KisiSilelimMi(int KisiId)
        {
            Kisi kisi = _kisiManager.GetAllKisi(x => x.KisiID == KisiId).FirstOrDefault();
            TempData["Message"] = _kisiManager.DeleteKisi(kisi);
            return RedirectToAction("../Home/Index");
        }
    }
}
