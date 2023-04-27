using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using EntityLayer;

namespace DAL
{
    public interface ILogin
    {
        public ArrayList Signin(SigninModel login);
        public bool SignupUser(SignupModel newUser);
    }
}
