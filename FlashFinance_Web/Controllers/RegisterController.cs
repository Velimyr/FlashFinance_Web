using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace FlashFinance_Web.Controllers
{
    public class RegisterController : Controller
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

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FilterRegister(DateTime begin , DateTime end)
        {
            if (begin==null)
            {
                begin = DateTime.Parse(DateTime.Now.Year + "-01-01");
            }
            if (end==null)
            {
                end = DateTime.Parse(DateTime.Now.Year + "-12-31");
            }
            //ViewBag.Bills = db.Bills;
            ViewBag.Registers = db.P_FlashFinance_Registers_Get(begin, end);

           // return View("~/Views/Home/Index.cshtml");
            var json_data = Json(ViewBag.Registers);
            return json_data;
        }

        [HttpPost]
        public ActionResult FilterRegister_NoJquery()
        {
            string begin = Request["begin"].ToString();
            string end = Request["end"].ToString();
            if ((begin == null) || (begin==""))
            {
                begin = DateTime.Parse(DateTime.Now.Year + "-01-01").ToString();
            }
            if ((end == null)|| (end == ""))
            {
                end = DateTime.Parse(DateTime.Now.Year + "-03-31").ToString();
            }
            ViewBag.Bills = db.Bills;
            ViewBag.Registers = db.P_FlashFinance_Registers_Get(DateTime.Parse(begin), DateTime.Parse(end));

            return PartialView("~/Views/Home/Index.cshtml");
            
        }
    }
}

