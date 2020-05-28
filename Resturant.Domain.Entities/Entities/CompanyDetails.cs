using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("CompanyDetails", Schema = "t_r")]
    public class CompanyDetails
    {
        [Key]
        public int CompanyId { set; get; }
        public string CompanyName { set; get; }
        public string CompanyUrl { set; get; }
        public string CompanyLogo { set; get; }
        public string CompanyBanner { set; get; }
        public decimal ResturantProfit { set; get; }
        public decimal ResturantShareableProfit { set; get; }
        public int ResturantTotalCustomerShare { set; get; }
        public byte ResturantPercentage { set; get; }
        public byte ResturantCustomerPercentage { set; get; }

    }
}
