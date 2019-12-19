using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Business.DomainClasses
{
    public class OrderLine
    {
        [Key]
        [Display(Name = "Order Line Id")]
        public int OrderLineID { get; set; }

        [ForeignKey("salesOrder")]
        public int SalesOrderID { get; set; }

        [ForeignKey("product")]
        [Display(Name = "Product Id")]
        public int ProductID { get; set; }

        [Display(Name = "Quantity Ordered")]
        public int QuantityOrdered{ get; set; }

        public virtual Product product { get; set; }
        public virtual SalesOrder salesOrder { get; set; }
    }
}
