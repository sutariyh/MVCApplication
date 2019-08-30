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
    public class Work_CenterController : Controller
    {
        private Entities db = new Entities();

        // GET: Work_Center
        public ActionResult Index()
        {
            return View(db.Work_Center.ToList());
        }

        // GET: Work_Center/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Center work_Center = db.Work_Center.Find(id);
            if (work_Center == null)
            {
                return HttpNotFound();
            }
            return View(work_Center);
        }

        // GET: Work_Center/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Work_Center/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "workcenterID,workcenterLocation")] Work_Center work_Center)
        {
            if (ModelState.IsValid)
            {
                db.Work_Center.Add(work_Center);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work_Center);
        }

        // GET: Work_Center/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Center work_Center = db.Work_Center.Find(id);
            if (work_Center == null)
            {
                return HttpNotFound();
            }
            return View(work_Center);
        }

        // POST: Work_Center/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "workcenterID,workcenterLocation")] Work_Center work_Center)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_Center).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_Center);
        }

        // GET: Work_Center/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Center work_Center = db.Work_Center.Find(id);
            if (work_Center == null)
            {
                return HttpNotFound();
            }
            return View(work_Center);
        }

        // POST: Work_Center/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Work_Center work_Center = db.Work_Center.Find(id);
            db.Work_Center.Remove(work_Center);
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
