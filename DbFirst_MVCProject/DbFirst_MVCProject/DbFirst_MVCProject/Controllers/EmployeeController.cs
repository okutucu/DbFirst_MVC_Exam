using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbFirst_MVCProject.DesignPatterns.SingletonPattern;
using DbFirst_MVCProject.Models;

namespace DbFirst_MVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        NORTHWNDEntities _db;

        public EmployeeController()
        {
            _db = DBTool.DBInstance;
        }

        public object DbTool { get; }

        // GET: Employee
        public ActionResult BringEmployees()
        {
            return View(_db.Employees.ToList());
        }
    }
}