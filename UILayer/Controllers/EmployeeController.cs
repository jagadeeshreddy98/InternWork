using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using EntityLayer;
using DAL.Models;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace UILayer.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        public IEmployee Emp;
        DAL.Models.EmployeeWebApiContext db = new DAL.Models.EmployeeWebApiContext();
        public EmployeeController(IEmployee Emp)
        {
            this.Emp = Emp;
        }


        public IActionResult DisplayAllEmployees(string Empsearch)
        {
            List<EmployeeModel> plist = Emp.DisplayAllEmployees();
            {
                ViewData["GetEmployeeDetails"] = Empsearch;



                var empquery = from x in Emp.DisplayAllEmployees() select x;
                if (!string.IsNullOrEmpty(Empsearch))
                {
                    empquery = empquery.Where(x => x.First_Name.Contains(Empsearch) || x.Email.Contains(Empsearch));
                }
                return View(empquery);
            }
            try
            {
                if(plist.Count>0)
                {
                    return View(plist);
                }
                else
                {
                    throw new Exception("List is empty");
                }

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        public IActionResult DisplayByEmpId(int id)
        {
            EmployeeModel Rec = Emp.DisplayByEmployeeId(id);

            try
            {
                if(Rec!=null)
                {
                    return View(Rec);
                }
                else
                {
                    throw new Exception("Record not found");
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }           
        }
        
        [HttpPost]
        public IActionResult AddEmployee(EmployeeModel NewRec)
        {
            try
            {
                var AddRec= Emp.AddEmploye(NewRec);
                if(AddRec!=null)
                {

                    return RedirectToAction("DisplayAllEmployees");
                }
                else
                {
                    throw new Exception("Caanot Add employee");
                }

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            List<State> StateList = db.States.ToList();
            ViewBag.StateList = new SelectList(StateList, "StateName", "StateName");
            return View();
        }

        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            EmployeeModel rec = Emp.DisplayByEmployeeId(id);

            try
            {
                if (rec != null)
                {
                    List<State> StateList = db.States.ToList();
                    ViewBag.StateList = new SelectList(StateList, "StateName", "StateName");
                    return View(rec);
                }
                else
                {
                    throw new Exception("Id not found");
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            

           
        }
        [HttpPost]
        public IActionResult EditEmployee(EmployeeModel updRec)
        {
            try
            {
                if(updRec!=null)
                {
                    Emp.EditEmployee(updRec);
                    return RedirectToAction("DisplayAllEmployees");
                }
                else
                {
                    throw new Exception("Validation error");
                }
                
            }
            catch(Exception e)
            {
                throw new Exception("Cannot Update");
            }
            
        }
        
        public IActionResult DeleteEmployee(int id) 
        {
            try
            {
                var DelEmp=Emp.DeleteEmployee(id);
                if(DelEmp!=null)
                {
                    return RedirectToAction("DisplayAllEmployees");
                }
                else
                {
                    throw new Exception("Deletion failed");
                }
                
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
      
    }
}
