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
        private EmployeeWebApiContext db;
        public LoginDataService(EmployeeWebApiContext db)
        {
            this.db = db;
        }



        public ArrayList Signin(SigninModel login)
        {
            UserDetail user = new UserDetail();
            try
            {
                user = db.UserDetails.Find(login.Username);

                if(user!=null)
                {
                    if (user.Username == login.Username & user.Password == login.Password)
                    {
                        ArrayList arr = new ArrayList();
                        var empdata = db.Employees.Find(user.EmployeeId);
                        var data = db.Roletbs.Find(empdata.RoleId);
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
                throw new Exception(e.Message);
            }
        }



        public bool SignupUser(SignupModel newuser)
        {

            var user = db.Employees.Find(newuser.EmployeeId);
            if (user != null)
            {
                if (newuser.EmployeeId == user.EmployeeId & newuser.Email == user.Email)
                {
                    UserDetail newrec = new UserDetail();
                    newrec.EmployeeId = newuser.EmployeeId;
                    newrec.Email = newuser.Email;
                    newrec.Password = newuser.Password;
                    newrec.Username = newuser.Username;
                    db.UserDetails.Add(newrec);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    throw new InvalidUserException("You are not an Employee");
                }
            }
            else
            {
                throw new InvalidUserException("Employee not found");
            }
            
        }

    }

    class InvalidUserException: ApplicationException
    {
        public InvalidUserException(string msg):base(msg)
        { }
    }

}

       