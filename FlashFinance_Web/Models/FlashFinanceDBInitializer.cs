using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace FlashFinance_Web.Models
{
    public class FlashFinanceDBInitializer : DropCreateDatabaseAlways<FinanceContext>
    {
        protected override void Seed(FinanceContext context)
        {
            context.Bills.Add(new Bills{ Id = 1, Bill_name = "Готівка" , Bill_balance = 0, Created_Date = DateTime.Now.ToLocalTime(), Currency = "UAH" });
            context.Bills.Add(new Bills { Id = 2, Bill_name = "Банківська карта", Bill_balance = 0, Created_Date = DateTime.Now.ToLocalTime(), Currency = "UAH" });
            context.Bills.Add(new Bills { Id = 3, Bill_name = "Відкладені", Bill_balance = 0, Created_Date = DateTime.Now.ToLocalTime(), Currency = "UAH" });
            context.Bills.Add(new Bills { Id = 4, Bill_name = "Долари", Bill_balance = 0, Created_Date = DateTime.Now.ToLocalTime(), Currency = "USD" });
            context.Bills.Add(new Bills { Id = 5, Bill_name = "Євро", Bill_balance = 0, Created_Date = DateTime.Now.ToLocalTime(), Currency = "EUR" });
            base.Seed(context);
        }
    }
}