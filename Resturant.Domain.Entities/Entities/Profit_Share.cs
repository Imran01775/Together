using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("Profit_Share", Schema = "t_r")]
    public class Profit_Share
    {
        [Key]
        public int Profit_ShareId { set; get; }
        public decimal ProfitPerCustomer { set; get; }
        public DateTime StartDate { set; get; }

        public DateTime EndDate { set; get; }

        public int Status { set; get; }

        public byte IsComplete { set; get; }
    }
}
