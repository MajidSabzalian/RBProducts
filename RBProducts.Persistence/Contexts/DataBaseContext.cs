using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RBProducts.Application.Contexts;
using RBProducts.Domain.Entities.ApplicationUser;
using RBProducts.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RBProducts.Persistence.Contexts
{
    public class DataBaseContext : IdentityDbContext<IdentityUser>, IDataBaseContext
    {
        public DbSet<Product> Products { set; get; }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Product>().Property(m => m.Name).HasMaxLength(100);
            mb.Entity<Product>().Property(m => m.ManufactureEmail).HasMaxLength(50);
            mb.Entity<Product>().Property(m => m.ManufacturePhone).HasMaxLength(11);
            mb.Entity<Product>().HasIndex(sm=> new { sm.ProduceDate, sm.ManufactureEmail }).IsUnique(true);

            // show only active records
            mb.Entity<Product>().HasQueryFilter(m => !m.IsRemovedRecord);
            
            base.OnModelCreating(mb);

            mb.Entity<AppUser>(b => { b.HasMany(p => p.Products); });
        }
    }
}
