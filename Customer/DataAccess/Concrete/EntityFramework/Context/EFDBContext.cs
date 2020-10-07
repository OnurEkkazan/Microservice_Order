using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class EFDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbServer = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("SERVERNAME")) != true ? Environment.GetEnvironmentVariable("SERVERNAME") : "sqldata";
            var dbName = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("DATABASE")) != true ? Environment.GetEnvironmentVariable("DATABASE") : "OrderCustomer";
            var dbPass = String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PASSWORD")) != true ? Environment.GetEnvironmentVariable("PASSWORD") : "Password1*";

            optionsBuilder.UseSqlServer(@"Server=" + dbServer + ",1433;Initial Catalog=" + dbName + ";User Id=sa; Password=" + dbPass);
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
