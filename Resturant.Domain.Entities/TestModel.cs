using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Resturant.Domain.Entities
{
    [Table("Test_Table")]
    public class TestModel
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
    }
}
