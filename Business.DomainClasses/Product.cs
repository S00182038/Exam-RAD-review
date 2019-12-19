using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.DomainClasses
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Stock Date")]
        public DateTime FirstStockDate { get; set; }
        [Display(Name = "Unit Cost")]
        public decimal UnitCost { get; set; }
        [Display(Name = "Quantity")]
        public int QuantityInStock { get; set; }
        [Display(Name = "Re-Order Quantity")]
        public int ReOrderQuantity { get; set; }

        public virtual IEnumerable <OrderLine> orderLines{ get; set; }

    }
}
