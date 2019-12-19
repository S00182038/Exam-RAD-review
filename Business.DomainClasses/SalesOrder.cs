using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business.DomainClasses
{
    public class SalesOrder
    {
        [Key]
        [Display(Name = "Sales Order Id")]
        public int SalesOrderID { get; set; }

        [ForeignKey("customer")]
        [Display(Name = "Customer Id")]
        public int CustomerID { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public virtual Customer customer { get; set; }
    }
}
