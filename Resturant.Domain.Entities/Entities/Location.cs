using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("Location", Schema = "t_r")]
    public class Location
    {
        [Key]
        public int LocationId { set; get; }
        public string BranchName { set; get; }
        public bool IsActive { set; get; }
    }
}
