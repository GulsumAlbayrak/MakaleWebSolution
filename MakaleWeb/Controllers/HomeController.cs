using MakaleWeb.BusinessLayer;
using MakaleWeb.Entities;
using MakaleWeb.Entities.ViewModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MakaleWeb.Controllers
{
    public class HomeController : Controller
    {
        private MakaleYonet makaleyonet = new MakaleYonet();
        private KategoriYonet kategoriyonet = new KategoriYonet();
        private KullaniciYonet kullaniciyonet = new KullaniciYonet();
        // GET: Home
        public ActionResult Index()
        {
            //BusinessLayer.Test databasetest = new BusinessLayer.Test();
            //databasetest.InsertTest();
            ////databasetest.UpdateTest();
            ////databasetest.DeleteTest();
            ////databasetest.YorumTest();
            //List<Makaleler> liste = makaleyonet.MakaleGetir();
            //return View(makaleyonet.MakaleGetir());

            //return View(makaleyonet.MakaleGetir().OrderByDescending(x => x.DegistirmeTarihi).ToList());

            return View(makaleyonet.ListQueryable().Where(x => x.Taslakmi == false).OrderByDescending(x => x.DegistirmeTarihi).ToList());
        }

        public ActionResult Kategori(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                    
            Kategoriler kat= kategoriyonet.IDKategoriGetir(id.Value);

            if(kat==null)
            {
                return HttpNotFound();
            }

            List<Makaleler> makale = new List<Makaleler>();

            makale = makaleyonet.ListQueryable().Where(
          x => x.Taslakmi == false && x.KategorilerID == id).OrderByDescending(
          x => x.OlusturmaTarihi).ToList();

            return View("Index",makale);

            //return View("Index",kat.Makaleler.OrderByDescending(x=>x.OlusturmaTarihi).ToList());
        }

        public ActionResult EnBegenilenler()
        {
            return View("Index",makaleyonet.MakaleGetir().OrderByDescending(x => x.BegeniSayisi).ToList());
        }
        
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(LoginModal model)
        {
            if (ModelState.IsValid)
            {
                KullaniciYonet ky = new KullaniciYonet();
                BLHatalar<Kullanicilar> kayitsonuc = ky.LoginUser(model);

                if (kayitsonuc.Hata.Count > 0)
                {
                    kayitsonuc.Hata.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }

                Session["login"] = kayitsonuc.sonuc;

                //Kullanicilar user = httpcontext.current.session["login"] as Kullanicilar;
                //return user.username
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Cikis()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(KayitModal model)
        {
            if (ModelState.IsValid)
            {
                KullaniciYonet ky = new KullaniciYonet();
                BLHatalar<Kullanicilar> kayitsonuc = ky.KullaniciKayit(model);

                if (kayitsonuc.Hata.Count > 0)
                {
                    kayitsonuc.Hata.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }
             }
                return RedirectToAction("Giris");
            
        }

        //public ActionResult UserActivate(Guid id)
        //{
        //    BLHatalar<Kullanicilar> kayitsonuc = kullaniciyonet.AktifEt(id);

        //    if (kayitsonuc.Hata.Count > 0)
        //    {
        //        ErrorViewModel errorNotifyObj = new ErrorViewModel()
        //        {
        //            Title = "Geçersiz İşlem",
        //            Items = kayitsonuc.Hata;
        //        };

        //        return View("Error", errorNotifyObj);
        //    }

        //    OkViewModel okNotifyObj = new OkViewModel()
        //    {
        //        Title = "Hesap Aktifleştirildi",
        //        RedirectingUrl = "/Home/Login"
        //    };

        //    okNotifyObj.Items.Add("Hesabınız aktifleştirildi. Artık not paylaşabilir ve beğenme yapabilirsiniz.");

        //    return View("Ok", okNotifyObj);
        //}
    }
}