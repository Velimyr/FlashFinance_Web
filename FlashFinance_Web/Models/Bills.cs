using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlashFinance_Web.Models
{
    public class Bills
    {
        //Ідентифікатор запису про рахунок
        
        public int Id { get; set; }
        //Назва рахунку
        public string Bill_name { get; set; }
        //Початковий баланс рахунку
        public int Bill_balance { get; set; }
        //Дата і час створення рахунку
        public DateTime Created_Date { get; set; }
        //Валюта рахунку
        public string Currency { get; set; }

    }
}