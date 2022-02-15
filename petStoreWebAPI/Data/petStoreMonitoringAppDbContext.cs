using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using petStoreWebAPI.Models;

namespace petStoreWebAPI.Data
{
    public class petStoreMonitoringAppDbContext : DbContext
    {
        public petStoreMonitoringAppDbContext(DbContextOptions<petStoreMonitoringAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<petStoreWebAPI.Models.OnHandMerch> OnHandMerch { get; set; }
        public DbSet<petStoreWebAPI.Models.AnimalPurchaseCategory> AnimalPurchaseCategory { get; set; }
        public DbSet<petStoreWebAPI.Models.OrderState> OrderState { get; set; }
        public DbSet<petStoreWebAPI.Models.Session> Session { get; set; }
    }
}
