using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("Order_Item", Schema = "t_r")]
    public class Order_Item
    {
        [Key]
        public int OrderItemId { set; get; }
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int ProductQuantity { set; get; }
        public int SellUnitPrice { set; get; }
        public int TotalPrice { set; get; }
        public byte ProductCostPercentage { set; get; }
        public byte CompanyPercentage { set; get; }

        public byte CustomerPercentage { set; get; }

    }
}
