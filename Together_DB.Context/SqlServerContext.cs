using Microsoft.EntityFrameworkCore;
using Resturant.Domain.Entities;
using Resturant.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Together_DB.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }
        public DbSet<TestModel> TestModel { set; get; }
        public DbSet<CompanyDetails> CompanyDetails { set; get; }
        public DbSet<Customer> Customer { set; get; }
        public DbSet<Customer_Profit_Track_Log> Customer_Profit_Track_Log { set; get; }
        public DbSet<CustomerBuyShare> CustomerBuyShare { set; get; }
        public DbSet<Employee> Employee { set; get; }
        public DbSet<Location> Location { set; get; }
        public DbSet<Order_Item> Order_Item { set; get; }
        public DbSet<Product> Product { set; get; }
        public DbSet<Profit_Share> Profit_Share { set; get; }
        public DbSet<ResturantOrder> Order { set; get; }
        public DbSet<Status> Status { set; get; }
        public DbSet<UserType> UserType { set; get; }


    }
}
