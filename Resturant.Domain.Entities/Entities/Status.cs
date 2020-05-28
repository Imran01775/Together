using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("Status", Schema = "t_r")]
    public class Status
    {
        [Key]
        public int StatusId { set; get; }
        public string StatusName { set; get; }
        public bool IsActive { set; get; }
        public string StatusGroup { set; get; }
    }
}
