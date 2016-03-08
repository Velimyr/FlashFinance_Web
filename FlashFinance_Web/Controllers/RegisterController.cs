using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlashFinance_Web.Controllers
{
    public class RegisterController : Controller
    {

        FlashFinanceEntities db = new FlashFinanceEntities();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


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
            ViewBag.Bills = db.Bills;
            ViewBag.Registers = db.P_FlashFinance_Registers_Get(begin, end);
            return View("~/Views/Home/Index.cshtml");
        }
    }
}