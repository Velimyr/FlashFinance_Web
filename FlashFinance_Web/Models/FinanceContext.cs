using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlashFinance_Web.Models
{
    public class FinanceContext : DbContext
    {
        public DbSet<Registers> Registers { get; set; }
        public DbSet<Bills> Bills { get; set; }
    }
}