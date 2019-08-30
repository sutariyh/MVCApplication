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
    public class Produced_InController : Controller
    {
        private Entities db = new Entities();

        // GET: Produced_In
        public ActionResult Index()
        {
            var produced_In = db.Produced_In.Include(p => p.Product).Include(p => p.Work_Center);
            return View(produced_In.ToList());
        }

        // GET: Produced_In/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produced_In produced_In = db.Produced_In.Find(id);
            if (produced_In == null)
            {
                return HttpNotFound();
            }
            return View(produced_In);
        }

        // GET: Produced_In/Create
        public ActionResult Create()
        {
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription");
            ViewBag.workcenterID = new SelectList(db.Work_Center, "workcenterID", "workcenterLocation");
            return View();
        }

        // POST: Produced_In/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "producedinID,productID,workcenterID")] Produced_In produced_In)
        {
            if (ModelState.IsValid)
            {
                db.Produced_In.Add(produced_In);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription", produced_In.productID);
            ViewBag.workcenterID = new SelectList(db.Work_Center, "workcenterID", "workcenterLocation", produced_In.workcenterID);
            return View(produced_In);
        }

        // GET: Produced_In/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produced_In produced_In = db.Produced_In.Find(id);
            if (produced_In == null)
            {
                return HttpNotFound();
            }
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription", produced_In.productID);
            ViewBag.workcenterID = new SelectList(db.Work_Center, "workcenterID", "workcenterLocation", produced_In.workcenterID);
            return View(produced_In);
        }

        // POST: Produced_In/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "producedinID,productID,workcenterID")] Produced_In produced_In)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produced_In).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription", produced_In.productID);
            ViewBag.workcenterID = new SelectList(db.Work_Center, "workcenterID", "workcenterLocation", produced_In.workcenterID);
            return View(produced_In);
        }

        // GET: Produced_In/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produced_In produced_In = db.Produced_In.Find(id);
            if (produced_In == null)
            {
                return HttpNotFound();
            }
            return View(produced_In);
        }

        // POST: Produced_In/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Produced_In produced_In = db.Produced_In.Find(id);
            db.Produced_In.Remove(produced_In);
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
