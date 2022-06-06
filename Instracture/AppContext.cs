using Microsoft.EntityFrameworkCore;
using System;

namespace ServerNet.Instracture
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options)
          : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


    }
}