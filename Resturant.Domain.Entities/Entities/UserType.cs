using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("UserType", Schema = "t_r")]
    public class UserType
    {
        [Key]
        public int UserTypeId { set; get; }
        public string UserTypeName { set; get; }
        public bool IsActive { set; get; }
        public string UserGroup { set; get; }
    }
}
