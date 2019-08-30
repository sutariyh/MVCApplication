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
    public class Does_Business_InController : Controller
    {
        private Entities db = new Entities();

        // GET: Does_Business_In
        public ActionResult Index()
        {
            var does_Business_In = db.Does_Business_In.Include(d => d.Customer).Include(d => d.Territory);
            return View(does_Business_In.ToList());
        }

        // GET: Does_Business_In/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Does_Business_In does_Business_In = db.Does_Business_In.Find(id);
            if (does_Business_In == null)
            {
                return HttpNotFound();
            }
            return View(does_Business_In);
        }

        // GET: Does_Business_In/Create
        public ActionResult Create()
        {
            ViewBag.customerID = new SelectList(db.Customers, "customerID", "customerName");
            ViewBag.territoryID = new SelectList(db.Territories, "territoryID", "territoryName");
            return View();
        }

        // POST: Does_Business_In/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "businessID,territoryID,customerID")] Does_Business_In does_Business_In)
        {
            if (ModelState.IsValid)
            {
                db.Does_Business_In.Add(does_Business_In);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customerID = new SelectList(db.Customers, "customerID", "customerName", does_Business_In.customerID);
            ViewBag.territoryID = new SelectList(db.Territories, "territoryID", "territoryName", does_Business_In.territoryID);
            return View(does_Business_In);
        }

        // GET: Does_Business_In/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Does_Business_In does_Business_In = db.Does_Business_In.Find(id);
            if (does_Business_In == null)
            {
                return HttpNotFound();
            }
            ViewBag.customerID = new SelectList(db.Customers, "customerID", "customerName", does_Business_In.customerID);
            ViewBag.territoryID = new SelectList(db.Territories, "territoryID", "territoryName", does_Business_In.territoryID);
            return View(does_Business_In);
        }

        // POST: Does_Business_In/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "businessID,territoryID,customerID")] Does_Business_In does_Business_In)
        {
            if (ModelState.IsValid)
            {
                db.Entry(does_Business_In).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customerID = new SelectList(db.Customers, "customerID", "customerName", does_Business_In.customerID);
            ViewBag.territoryID = new SelectList(db.Territories, "territoryID", "territoryName", does_Business_In.territoryID);
            return View(does_Business_In);
        }

        // GET: Does_Business_In/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Does_Business_In does_Business_In = db.Does_Business_In.Find(id);
            if (does_Business_In == null)
            {
                return HttpNotFound();
            }
            return View(does_Business_In);
        }

        // POST: Does_Business_In/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Does_Business_In does_Business_In = db.Does_Business_In.Find(id);
            db.Does_Business_In.Remove(does_Business_In);
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
