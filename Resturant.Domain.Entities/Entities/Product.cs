using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("Product", Schema = "t_r")]
    public class Product
    {
        [Key]
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public int ProductCost { set; get; }
        public int ProductSellAmount { set; get; }
        public byte ProductCostPercentage { set; get; }
        public byte CompanyPercentage { set; get; }
        public byte CustomerPercentage { set; get; }
        public bool IsAvailable { set; get; }
    }
}
