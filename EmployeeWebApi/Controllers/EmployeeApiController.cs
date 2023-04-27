using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using DAL;
using EntityLayer;

namespace EmployeeWebApi.Controllers
{
    //[Route("api/[controller]")]
    
    [ApiController]
    public class EmployeeApiController : ControllerBase
    {
        private EmployeeDataService _empser;
        public EmployeeApiController(EmployeeDataService empser)
        {
            _empser = empser;
        }



        [HttpPut]
        [Route("EditEmployee")]
        public IActionResult EditEmployee(EmployeeModel emp)
        {
            EmployeeModel empList = new EmployeeModel();
            //EmployeeModel? emp;
            try
            {
                empList = _empser.EditEmployee(emp);
                return Ok(empList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("EmployeeDetail")]
        public IActionResult DisplayAllEmployees()
        {
            List<EmployeeModel> empList = new List<EmployeeModel>();
            try
            {
                empList = _empser.DisplayAllEmployees();
                return Ok(empList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("DisplayByEmpId/{id}")]
        public IActionResult DisplayByEmpId(int id)
        {
            EmployeeModel empList = new EmployeeModel();
            try
            {
                empList = _empser.DisplayByEmployeeId(id);
                return Ok(empList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            EmployeeModel empList = new EmployeeModel();
            try
            {
                empList = _empser.DeleteEmployee(id);
                return Ok(empList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("AddEmployees")]
        public IActionResult AddEmployee(EmployeeModel emp)
        {
            EmployeeModel empList = new EmployeeModel();
            try
            {
                empList = _empser.AddEmploye(emp);
                return Ok(empList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}