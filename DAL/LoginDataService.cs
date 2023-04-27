using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using EntityLayer;

namespace DAL
{
    public class LoginDataService : ILogin
    {
        private EmployeeWebApiContext _db;
        public LoginDataService(EmployeeWebApiContext db)
        {
            _db = db;
        }

        public ArrayList Signin(SigninModel login)
        {
            UserDetail user = new UserDetail();
            ArrayList arr = new ArrayList();
            try
            {
                user = _db.UserDetails.Find(login.Username);

                if(user!=null)
                {
                    if (user.Username == login.Username & user.Password == login.Password)
                    {
                        var empdata = _db.Employees.Find(user.EmployeeId);
                        var data = _db.Roletbs.Find(empdata.RoleId);
                        arr.Add(data.RoleName);
                        arr.Add(user.EmployeeId);
                        return arr;
                    }
                    else
                    {
                        throw new Exception("Wrong");
                    }
                }
                else
                {
                    throw new Exception("user not found");
                }
            }
            catch (Exception e)
            {
                return arr;
            }
        }



        public bool SignupUser(SignupModel newuser)
        {

            var user = _db.Employees.Find(newuser.EmployeeId);
            if (user != null)
            {
                if (newuser.EmployeeId == user.EmployeeId & newuser.Email == user.Email)
                {
                    UserDetail newrec = new UserDetail();
                    newrec.EmployeeId = newuser.EmployeeId;
                    newrec.Email = newuser.Email;
                    newrec.Password = newuser.Password;
                    newrec.Username = newuser.Username;
                    _db.UserDetails.Add(newrec);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("You are not an Employee");
                }
            }
            else
            {
               
                throw new Exception("Employee not found");
            }
            
        }

    }
}

       