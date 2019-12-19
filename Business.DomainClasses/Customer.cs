using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DomainClasses
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }

        public virtual IEnumerable<SalesOrder> salesOrders { get; set; }
    }
}
