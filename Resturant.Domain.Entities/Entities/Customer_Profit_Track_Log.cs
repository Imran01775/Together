using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("Customer_Profit_Track_Log", Schema = "t_r")]
    public class Customer_Profit_Track_Log
    {
        [Key]
        public int Customer_Profit_Track_Id { set; get; }
        public int CustomerId { set; get; }
        public int TotalCustomerShare { set; get; }
        public decimal ProfitShareAmount { set; get; }
        public int Profit_Share_Id { set; get; }
    }
}
