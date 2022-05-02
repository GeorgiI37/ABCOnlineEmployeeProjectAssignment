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
    public class ManagerController : Controller
    {
        private ABCEmployeeDBEntities db = new ABCEmployeeDBEntities();

        // GET: Coordinators
        public ActionResult Index()
        {
            return View(db.Managers.ToList());
        }

        // GET: Coordinators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager Manager = db.Managers.Find(id);
            if (Manager == null)
            {
                return HttpNotFound();
            }
            return View(Manager);
        }

        // GET: Coordinators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coordinators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id, FirstName, LastName, Email, Password")] Manager mManager)
        {
            if (ModelState.IsValid)
            {
                db.Managers.Add(mManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mManager);
        }

        // GET: Coordinators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager mManager = db.Managers.Find(id);
            if (mManager == null)
            {
                return HttpNotFound();
            }
            return View(mManager);
        }

        // POST: Coordinators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, FirstName, LastName, Email, Password")] Manager mManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mManager);
        }

        // GET: Coordinators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager mManager = db.Managers.Find(id);
            if (mManager == null)
            {
                return HttpNotFound();
            }
            return View(mManager);
        }

        // POST: Coordinators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manager Manager = db.Managers.Find(id);
            db.Managers.Remove(Manager);
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
