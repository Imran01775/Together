using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("CustomerBuyShare", Schema ="t_r")]
    public class CustomerBuyShare
    {
        [Key]
        public int CustomerBuyShareId { set; get; }
        public int CustomerId { set; get; }
        public int PurchaseAmount { set; get; }
        public int PerShareAmount { set; get; }
        public int NumberOfShare { set; get; }

    }
}
