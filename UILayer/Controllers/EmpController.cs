using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL;
using DAL.Models;
using EntityLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace UILayer.Controllers
{
   // [Route("api/[controller]/[action]")]
   [Authorize]
    public class EmpController : Controller
    {
        public IEmployee Emp;
        DAL.Models.EmployeeWebApiContext db = new DAL.Models.EmployeeWebApiContext();
        public EmpController(IEmployee Emp)
        {
            this.Emp = Emp;
        }
        [HttpGet]
        public IActionResult UpdateEmp(int id)
        {

            EmployeeModel rec = Emp.DisplayByEmployeeId(id);
            List<State> StateList = db.States.ToList();
            ViewBag.StateList = new SelectList(StateList, "StateName", "StateName");

            return View(rec);

        }

        [HttpPost]
        public IActionResult UpdateEmp(EmployeeModel updRec)
        {
            try
            {
                if (updRec != null)
                {
                    Emp.EditEmployee(updRec);
                    return RedirectToAction("ShowEmpById", "Emp", new { @id = updRec.EmployeeId });
                }

                else
                {
                    throw new Exception("Validation error");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Cannot Update");
            }
        }


       public IActionResult ShowEmpById(int id)
       {

            EmployeeModel Rec = Emp.DisplayByEmployeeId(id);
            try
            {
                if (Rec != null)
                {
                    return View(Rec);
                }
                else
                {
                    throw new Exception("Record not found");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }



       }
    }
}
