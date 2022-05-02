using ABCOnlineEmployeeProjectAssignment.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ABCOnlineEmployeeProjectAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        private ABCEmployeeDBEntities db = new ABCEmployeeDBEntities();
        // GET: Employee
        public ActionResult Index()
        {
            using (var context = new ABCEmployeeDBEntities())
            {
                return View(context.Employees.ToList());
            }
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var context = new ABCEmployeeDBEntities())
            {
                Employee Employee = context.Employees.Find(id);
                if (Employee == null)
                {
                    return HttpNotFound();
                }
                return View(Employee);
            }
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeNumber,FirstName,LastName,Email")] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee Employee = db.Employees.Find(id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            return View(Employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeNumber,FirstName,LastName,Email")] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee Employee = db.Employees.Find(id);
            if (Employee == null)
            {
                return HttpNotFound();
            }
            return View(Employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee Employee = db.Employees.Find(id);
            db.Employees.Remove(Employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}