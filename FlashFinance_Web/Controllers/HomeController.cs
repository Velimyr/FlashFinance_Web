using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//using FlashFinance_Web.Models;

namespace FlashFinance_Web.Controllers
{
    public class HomeController : Controller
    {
        public string CurrentLangCode { get; protected set; }
        
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
           if (requestContext.RouteData.Values["lang"] != null && requestContext.RouteData.Values["lang"] as string != "null")
            {
                CurrentLangCode = requestContext.RouteData.Values["lang"] as string;
                switch (CurrentLangCode)
                {
                    case "ua":
                        CurrentLangCode = "uk-UA";
                        break;
                    case "en":
                        CurrentLangCode = "en-GB";
                        break;
                    case "ru":
                        CurrentLangCode = "ru-RU";
                        break;
                    default:
                        CurrentLangCode = "uk-UA";
                        break;
                }

                var ci = new CultureInfo(CurrentLangCode);
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
            base.Initialize(requestContext);
        }
      FlashFinanceEntities db = new FlashFinanceEntities();
        public ActionResult Index()
        {
            ViewBag.Bills = db.Bills;
            ViewBag.Registers = db.Registers;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpGet]
        public ActionResult AddRegister ()
        {
            return View();
        }

        [HttpPost]
        public string AddRegister (Registers RegisterItem)
        {                       
            db.Registers.Add(RegisterItem);
            db.SaveChanges();
            return "Ok";
        }


 
      
    }
}