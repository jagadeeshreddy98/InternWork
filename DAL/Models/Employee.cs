using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Salary { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int? Pincode { get; set; }
        public int? MobileNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }

        public virtual Roletb Role { get; set; }
    }
}
