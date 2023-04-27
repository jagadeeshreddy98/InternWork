using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;

namespace DAL
{
   public  interface IEmployee
    {
        public List<EmployeeModel> DisplayAllEmployees();
        public EmployeeModel EditEmployee(EmployeeModel Emp);
        public EmployeeModel DisplayByEmployeeId(int id);
        public EmployeeModel DeleteEmployee(int id);
        public EmployeeModel AddEmploye(EmployeeModel EmpRec);
    }
}
