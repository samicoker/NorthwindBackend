using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connectionString:@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
            optionsBuilder.UseSqlServer(connectionString: @"Server=LAPTOP-KVVGNCFL; Database=Northwind; User Id=sa; Password=12345; Trusted_Connection=false; MultipleActiveResultSets=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
