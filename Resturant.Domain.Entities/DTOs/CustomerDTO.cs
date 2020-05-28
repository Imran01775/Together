using Resturant.Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resturant.Domain.Entities.DTOs
{
    public class CustomerDTO : Customer
    {
        public string UserTypeName { set; get; }
    }
}
