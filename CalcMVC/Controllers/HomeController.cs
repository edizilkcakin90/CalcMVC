using CalcMVC.Models;
using CalcMVC.Models.Context;
using CalcMVC.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace CalcMVC.Controllers
{

    public class HomeController : Controller
    {
        ProjectContext db;

        public HomeController()
        {
            db = new ProjectContext();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("/Home/HesapMakinesi");


        }
        
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(User model)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.Where(x=>x.UserName==model.UserName && x.Password==model.Password).FirstOrDefault();
                if (user!=null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, true);
                    return RedirectToAction("HesapMakinesi", "Home");
                }

                else
                {
                    return View();
                }
            }
            return View(model);
        }

        [SessionControl]
        public ActionResult HesapMakinesi()
        {
            
            return View();
        }

        [SessionControl]
        public ActionResult CikisYap()
        {
            Thread.Sleep(2000);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [SessionControl]
        public ActionResult Topla(string sayi1)
        {
            try
            {
                var sayilar = sayi1.Split(' ');

                int sayii = Convert.ToInt32(sayilar[0]);
                int sayi2 = Convert.ToInt32(sayilar[1]);

                TempData["sonuc"] = sayii + sayi2;
                return RedirectToAction("HesapMakinesi", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("HesapMakinesi", "Home");
            }
            
        }

        [SessionControl]
        public ActionResult Cikar(string sayi1)
        {
            try
            {
                if (sayi1.StartsWith("-"))
                {
                    var sayilar = sayi1.Split('-');

                    List<string> sayilarr = sayilar.ToList();
                    sayilarr.RemoveAt(0);

                    int sayii = Convert.ToInt32(sayilarr[0]);
                    int sayi2 = Convert.ToInt32(sayilarr[1]);

                    int sonuc = sayii + sayi2;
                    int ss = sonuc * (-1);

                    TempData["sonuc"] = ss;
                    return RedirectToAction("HesapMakinesi", "Home");
                }
                else
                {
                    var sayilar = sayi1.Split('-');

                    int sayii = Convert.ToInt32(sayilar[0]);
                    int sayi2 = Convert.ToInt32(sayilar[1]);

                    TempData["sonuc"] = sayii - sayi2;
                    return RedirectToAction("HesapMakinesi", "Home");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("HesapMakinesi", "Home");
            }
        }

        [SessionControl]
        public ActionResult Carp(string sayi1)
        {
            try
            {
                var sayilar = sayi1.Split('*');

                int sayii = Convert.ToInt32(sayilar[0]);
                int sayi2 = Convert.ToInt32(sayilar[1]);

                TempData["sonuc"] = sayii * sayi2;
                return RedirectToAction("HesapMakinesi", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("HesapMakinesi", "Home");
            }
            
        }

        [SessionControl]
        public ActionResult Bol(string sayi1)
        {
            try
            {
                var sayilar = sayi1.Split('/');

                int sayii = Convert.ToInt32(sayilar[0]);
                int sayi2 = Convert.ToInt32(sayilar[1]);

                TempData["sonuc"] = sayii / sayi2;
                return RedirectToAction("HesapMakinesi", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("HesapMakinesi", "Home");
            }
            
        }

        [SessionControl]
        public ActionResult Esit(string sayi1)
        {
            try
            {
                TempData["sonuc"] = Convert.ToInt32(sayi1);
                return RedirectToAction("HesapMakinesi", "Home");
            }
            catch (Exception)
            {
                return RedirectToAction("HesapMakinesi", "Home");
            }
            
        }

    }
}