using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities.Entities
{
    [Table("Employee", Schema = "t_r")]
    public class Employee
    {
        [Key]
        public int EmployeeId { set; get; }
        public string Name { set; get; } = "";
        public string Address { set; get; } = "";
        public string NID { set; get; } = "";
        public string Mobile { set; get; } = "";
        public string AlterMobile { set; get; } = "";
        public string Email { set; get; }

        public string Password { set; get; } = "admin";
        public int Salary { set; get; } = 0;
        public int UserTypeId { set; get; } = 0;
        public int LocationId { set; get; } = 0;

        public int InsertedBy { set; get; } = 0;
        public DateTime InsertedOn { set; get; } = DateTime.Now;
        public int UpdatedBy { set; get; } = 0;
        public DateTime UpdatedOn { set; get; }
        public bool IsActive { set; get; } = false;
    }
}
