using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses
{
    public class DataContext: DbContext
    {
        public DbSet<Customer> Costumers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }

        public DataContext() : base("SalesConnection")
        {
        }

        public static DataContext Create()
        {
            return new DataContext();
        }
    }
}
