using ABCOnlineEmployeeProjectAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABCOnlineEmployeeProjectAssignment.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Employees(Employee Employee)
        {
            using (var context = new ABCEmployeeDBEntities()) {
                bool isValid = context.Employees.Any(x => x.Email == Employee.Email);
                if (isValid)
                {
                    Session["Employee"] = context.Employees.SingleOrDefault(i => i.Email == Employee.Email).EmployeeNumber;
                    Session["Manager"] = null;
                    return RedirectToAction("Index", "Project");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Email or Password");
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult Manager()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Manager(Manager Manager)
        {
            using (var context = new ABCEmployeeDBEntities())
            {
                bool isValid = context.Managers.Any(x => x.Email == Manager.Email && x.Password == Manager.Password);
                if (isValid)
                {
                    Session["Manager"] = context.Managers.SingleOrDefault(i => i.Email == Manager.Email).Id;
                    Session["Employee"] = null;
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Email or Password");
                    return View();
                }

            }
        }
    }
}