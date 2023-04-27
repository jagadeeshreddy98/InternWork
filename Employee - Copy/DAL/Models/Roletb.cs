using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Roletb
    {
        public Roletb()
        {
            Employees = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
