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
    public class EmployeeProjectController : Controller
    {
        private ABCEmployeeDBEntities db = new ABCEmployeeDBEntities();

        // GET: EmployeeProject
        public ActionResult Index()
        {
            var EmployeeProjects = db.EmployeeProjects.Include(t => t.Project).Include(t => t.Employee);
            return View(EmployeeProjects.ToList());
        }

        // GET: EmployeeProject/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject EmployeeProject = db.EmployeeProjects.Find(id);
            if (EmployeeProject == null)
            {
                return HttpNotFound();
            }
            return View(EmployeeProject);
        }

        // GET: EmployeeProject/Create
        public ActionResult Create()
        {
            ViewBag.ProjectCode = new SelectList(db.Projects, "ProjectCode", "ProjectTitle");
            ViewBag.EmployeeNumber = new SelectList(db.Employees, "EmployeeNumber", "Email");
            return View();
        }

        // POST: EmployeeProject/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, EmployeeNumber,ProjectCode")] EmployeeProject EmployeeProject)
        {
            if (ModelState.IsValid)
            {
                if (db.EmployeeProjects.Where(e => e.EmployeeNumber == EmployeeProject.EmployeeNumber).Count() > 2)
                    return RedirectToAction("Index");

                db.EmployeeProjects.Add(EmployeeProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectCode = new SelectList(db.Projects, "ProjectCode", "ProjectTitle", EmployeeProject.ProjectCode);
            ViewBag.EmployeeNumber = new SelectList(db.Employees, "EmployeeNumber", "Email", EmployeeProject.EmployeeNumber);
            return View(EmployeeProject);
        }

        // GET: EmployeeProject/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject EmployeeProject = db.EmployeeProjects.Find(id);
            if (EmployeeProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectCode = new SelectList(db.Projects, "ProjectCode", "ProjectTitle", EmployeeProject.ProjectCode);
            ViewBag.EmployeeNumber = new SelectList(db.Employees, "EmployeeNumber", "Email", EmployeeProject.EmployeeNumber);
            return View(EmployeeProject);
        }

        // POST: EmployeeProject/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeNumber,ProjectCode,Id")] EmployeeProject EmployeeProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(EmployeeProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectCode = new SelectList(db.Projects, "ProjectCode", "ProjectTitle", EmployeeProject.ProjectCode);
            ViewBag.EmployeeNumber = new SelectList(db.Employees, "EmployeeNumber", "Email", EmployeeProject.EmployeeNumber);
            return View(EmployeeProject);
        }

        // GET: EmployeeProject/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject EmployeeProject = db.EmployeeProjects.Find(id);
            if (EmployeeProject == null)
            {
                return HttpNotFound();
            }
            return View(EmployeeProject);
        }

        // POST: EmployeeProject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeProject EmployeeProject = db.EmployeeProjects.Find(id);
            db.EmployeeProjects.Remove(EmployeeProject);
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
