using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL;
using EntityLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UILayer.Controllers
{
 
    public class LoginController : Controller
    {
        private ILogin _loginser;
        public LoginController(ILogin loginser)
        {
            _loginser = loginser;
        }
   
        public IActionResult SigninUser()
        {
            return View();
        }

        [HttpPost]
    

        public  IActionResult SigninUser(SigninModel model)
        {
            try
            {
                 var details = _loginser.Signin(model);
                if(details.Count>0)
                {
                    var role = (string)details[0];
                    var empid = (int)details[1];

                    var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Username) },
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    HttpContext.Session.SetString("Username", model.Username);

                  
                    if (role == "Admin")
                    {
                        HttpContext.Session.SetString("Username", model.Username);
                        return RedirectToAction("DisplayAllEmployees", "Employee");
                    }
                    else
                        return RedirectToAction("ShowEmpById", "Emp", new { @id = empid });

                }
                else
                {
                    /*  ViewBag.Alert = AlertService.ShowAlert(Alerts.Danger, "Invalid Credentials");*/
                    ViewBag.Alert = "Invalid Credentials";
                    throw new Exception("Invalid user details");
                }

            }
            
            catch (Exception e)
            {
                
                return View();
            }
        }
        public async Task<IActionResult> SignoutUser()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("SigninUser", "Login");
        }
        public IActionResult SignupUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignupUser(SignupModel newuser)
        {
            try
            {
                var isvalid = _loginser.SignupUser(newuser);
                if (isvalid == true)
                {
                    return RedirectToAction("SigninUser");
                }
                else
                {
                   
                    throw new Exception("Signup is not successful");
                }
            }
            catch (Exception e)
            {
                ViewBag.alert = "Employee not found";
                return View(); 
            }
        }
    }
}
