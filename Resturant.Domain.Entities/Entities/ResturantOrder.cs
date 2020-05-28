using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("Order", Schema = "t_r")]
    public class ResturantOrder
    {
        [Key]
        public int OrderId { set; get; }
        public string Order_Id { set; get; }
        public int CustomerId { set; get; }
        public int Price { set; get; }
        public decimal OrderTotalCostAmount { set; get; }


        public decimal CompanyAmount { set; get; }

        public decimal CustomerAmount { set; get; }
        public int InsertedBy { set; get; }
        public DateTime InsertedOn { set; get; } = DateTime.Now;
        public int UpdatedBy { set; get; }
        public DateTime UpdatedOn { set; get; }
        public int LocationId { set; get; }
        public int Status { set; get; }
    }
}
