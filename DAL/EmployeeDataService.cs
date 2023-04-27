using System;
using System.Collections.Generic;
using System.Text;
using EntityLayer;
using DAL.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.ModelBinding;



namespace DAL
{
    public class EmployeeDataService : IEmployee
    {
        private EmployeeWebApiContext _Db;
        public EmployeeDataService(EmployeeWebApiContext Db)
        {
            _Db = Db;
        }

        public List<EmployeeModel> DisplayAllEmployees()
        {
            List<Employee> Emp = new List<Employee>();
            List<EmployeeModel> lst = new List<EmployeeModel>();

            try
            {
                Emp = _Db.Employees.ToList();


                foreach (var d in Emp)
                {
                    EmployeeModel e = new EmployeeModel();
                    
                    e.EmployeeId = d.EmployeeId;
                    e.First_Name = d.FirstName;
                    e.Last_Name = d.LastName;
                    e.State = d.State;
                    e.City = d.City;
                    e.DateOfBirth = d.DateOfBirth;
                    e.Salary = d.Salary;
                    e.Mobile_Number = (int)d.MobileNumber;
                    e.Email = d.Email;
                    e.Pincode = d.Pincode;
                    e.RoleId = d.RoleId;
                    //e.State = d.State;

                    lst.Add(e);
                }
                return lst;

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmployeeModel DeleteEmployee(int id)
        {
            EmployeeModel? emp = new EmployeeModel();
            Employee? EmpRec;
            try
            {
                EmpRec = _Db.Employees.Find(id);
                if (EmpRec != null)
                {
                    _Db.Employees.Remove(EmpRec);
                    _Db.SaveChanges();
                    emp.EmployeeId = EmpRec.EmployeeId;
                    emp.First_Name = EmpRec.FirstName;
                    emp.Last_Name = EmpRec.LastName;
                    emp.State = EmpRec.State;
                    emp.City = EmpRec.City;
                    emp.DateOfBirth = EmpRec.DateOfBirth;
                    emp.Salary = EmpRec.Salary;
                    emp.Mobile_Number = (int)EmpRec.MobileNumber;
                    emp.Email = EmpRec.Email;
                    emp.Pincode = EmpRec.Pincode;
                    emp.RoleId = EmpRec.RoleId;

                    return emp;
                }
                else
                {
                    throw new Exception("Employee Record not Found");
                }
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmployeeModel AddEmploye(EmployeeModel EmpRec)
        {

            Employee rec = new Employee();
            rec.EmployeeId = EmpRec.EmployeeId;
            rec.FirstName = EmpRec.First_Name;
            rec.LastName = EmpRec.Last_Name;
            rec.State = EmpRec.StateName;
            rec.City = EmpRec.City;
            rec.DateOfBirth = EmpRec.DateOfBirth;
            rec.Salary = EmpRec.Salary;
            rec.MobileNumber = EmpRec.Mobile_Number;
            rec.Email = EmpRec.Email;
            rec.Pincode = EmpRec.Pincode;
            rec.RoleId = EmpRec.RoleId;
            try
            {
                _Db.Employees.Add(rec);
                _Db.SaveChanges();
                return EmpRec;
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    throw new Exception(e.InnerException.Message);
                }
                throw new Exception(e.Message);
            }
        }

       public EmployeeModel DisplayByEmployeeId(int id)
       {
            EmployeeModel? emp = new EmployeeModel();
            Employee? EmpRec;
           
            try
            {
                EmpRec = _Db.Employees.Find(id);
                if (EmpRec != null)
                {
                    emp.EmployeeId = EmpRec.EmployeeId;
                    emp.First_Name = EmpRec.FirstName;
                    emp.Last_Name = EmpRec.LastName;
                    emp.State = EmpRec.State;
                    emp.City = EmpRec.City;
                    emp.DateOfBirth = EmpRec.DateOfBirth;
                    emp.Salary = EmpRec.Salary;
                    emp.Mobile_Number = (int)EmpRec.MobileNumber;
                    emp.Email = EmpRec.Email;
                    emp.Pincode = EmpRec.Pincode;
                    emp.RoleId = EmpRec.RoleId;

                    return emp;
                }
                else
                {
                    throw new Exception("Employee Record not Found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
       }

        public EmployeeModel EditEmployee(EmployeeModel EmpRec)
        {
            var rec = _Db.Employees.Find(EmpRec.EmployeeId);
            
            try
            {
                if (rec != null)
                {
                    rec.EmployeeId = EmpRec.EmployeeId;
                    rec.FirstName = EmpRec.First_Name;
                    rec.LastName = EmpRec.Last_Name;
                    if (EmpRec.StateName != null)
                    {
                        rec.State = EmpRec.StateName;
                    }
                    if (EmpRec.RoleId != null)
                    {
                        rec.RoleId = EmpRec.RoleId;
                    }
                    rec.City = EmpRec.City;
                    rec.DateOfBirth = EmpRec.DateOfBirth;
                    rec.Salary = EmpRec.Salary;
                    rec.MobileNumber = EmpRec.Mobile_Number;
                    rec.Email = EmpRec.Email;
                    rec.Pincode = EmpRec.Pincode;

                    _Db.Entry(rec).State = EntityState.Modified;
                    _Db.SaveChanges();
                    return EmpRec;
                   
                }
                else
                {
                    throw new Exception("Updation failed");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
