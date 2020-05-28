using System;
using System.Collections.Generic;
using System.Text;

namespace Resturant.Domain.Entities
{
    public class LoginDataModel
    {
        public string Mobile { set; get; }
        public string Email { set; get; }
        public string Password { set; get; }
        public int UserType { set; get; } = 0;
    }
}
