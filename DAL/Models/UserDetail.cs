using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class UserDetail
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int? EmployeeId { get; set; }
        public string Email { get; set; }
    }
}
