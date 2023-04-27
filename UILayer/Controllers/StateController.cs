using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Extensions.Logging;
using DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UILayer.Controllers
{
    public class StateController : Controller
    {
        DAL.Models.EmployeeWebApiContext db = new DAL.Models.EmployeeWebApiContext();

        private readonly ILogger<StateController> _logger;
        public StateController(ILogger<StateController> logger)

        {

            _logger = logger;

        }
        public IActionResult State()

        {

            List<State> StateList = db.States.ToList();

            ViewBag.StateList = new SelectList(StateList, "Stateid", "StateName");


            return View();

        }

    }
}
