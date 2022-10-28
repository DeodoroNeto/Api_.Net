using ApiSysMap.Models;
using ApiSysMap.Data.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSysMap.Data
{
    public class SystemSalesDBContex : DbContext
    {
        public SystemSalesDBContex(DbContextOptions<SystemSalesDBContex>options)
            : base(options)
        {
        }
        public DbSet<UserModels> User { get; set; }
        public DbSet<ProductModels> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
