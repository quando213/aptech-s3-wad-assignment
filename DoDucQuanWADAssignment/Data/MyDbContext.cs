using DoDucQuanWADAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoDucQuanWADAssignment.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("ConnectionString")
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}