using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S2G6_PVFAPP.Models;

namespace S2G6_PVFAPP.Controllers
{
    public class Works_InController : Controller
    {
        private Entities db = new Entities();

        // GET: Works_In
        public ActionResult Index()
        {
            var works_In = db.Works_In.Include(w => w.Employee).Include(w => w.Work_Center);
            return View(works_In.ToList());
        }

        // GET: Works_In/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works_In works_In = db.Works_In.Find(id);
            if (works_In == null)
            {
                return HttpNotFound();
            }
            return View(works_In);
        }

        // GET: Works_In/Create
        public ActionResult Create()
        {
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeSupervisor");
            ViewBag.workscenterID = new SelectList(db.Work_Center, "workcenterID", "workcenterLocation");
            return View();
        }

        // POST: Works_In/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "worksinID,workscenterID,employeeID")] Works_In works_In)
        {
            if (ModelState.IsValid)
            {
                db.Works_In.Add(works_In);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeSupervisor", works_In.employeeID);
            ViewBag.workscenterID = new SelectList(db.Work_Center, "workcenterID", "workcenterLocation", works_In.workscenterID);
            return View(works_In);
        }

        // GET: Works_In/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works_In works_In = db.Works_In.Find(id);
            if (works_In == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeSupervisor", works_In.employeeID);
            ViewBag.workscenterID = new SelectList(db.Work_Center, "workcenterID", "workcenterLocation", works_In.workscenterID);
            return View(works_In);
        }

        // POST: Works_In/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "worksinID,workscenterID,employeeID")] Works_In works_In)
        {
            if (ModelState.IsValid)
            {
                db.Entry(works_In).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeSupervisor", works_In.employeeID);
            ViewBag.workscenterID = new SelectList(db.Work_Center, "workcenterID", "workcenterLocation", works_In.workscenterID);
            return View(works_In);
        }

        // GET: Works_In/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works_In works_In = db.Works_In.Find(id);
            if (works_In == null)
            {
                return HttpNotFound();
            }
            return View(works_In);
        }

        // POST: Works_In/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Works_In works_In = db.Works_In.Find(id);
            db.Works_In.Remove(works_In);
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
