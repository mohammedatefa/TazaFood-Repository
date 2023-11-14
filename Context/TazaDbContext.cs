﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TazaFood_Core.Models;
using TazaFood_Core.Models.Order_Aggregate;

namespace TazaFood_Repository.Context
{
    public class TazaDbContext:DbContext
    {
        public TazaDbContext(DbContextOptions<TazaDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //to excute the all configration on all classes of configration 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
    }

}
