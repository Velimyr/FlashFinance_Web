using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using FlashFinance_Web.Models;

namespace FlashFinance_Web.Controllers
{
    public class HomeController : Controller
    {
        FlashFinanceEntities db = new FlashFinanceEntities();
        public ActionResult Index()
        {
           // IEnumerable<Bills> bills = db.Bills;
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
            //if (RegisterItem.Id == 0)
            //{
            //    int MaxID = db.Registers.Max(r => r.Id);
            //    RegisterItem.Id = MaxID+1;
            //}
                       
            db.Registers.Add(RegisterItem);
            db.SaveChanges();
            return "Ok";
        }
    }
}