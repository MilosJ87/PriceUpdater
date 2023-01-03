using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using PriceUpdater.Entities;
using Microsoft.EntityFrameworkCore;

namespace PriceUpdater.DbContexts
{
    public class PriceUpdaterContext : DbContext
    {
        public PriceUpdaterContext(DbContextOptions<PriceUpdaterContext> options)
           : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Zlatne_Kovanice> ZlatneKovanice { get; set; }
        public DbSet<Zlatne_poluge> ZlatnePoluge { get; set; }
    }
}
