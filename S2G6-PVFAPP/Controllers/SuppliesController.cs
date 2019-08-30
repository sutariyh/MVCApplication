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
    public class SuppliesController : Controller
    {
        private Entities db = new Entities();

        // GET: Supplies
        public ActionResult Index()
        {
            var supplies = db.Supplies.Include(s => s.Raw_Material).Include(s => s.Vendor);
            return View(supplies.ToList());
        }

        // GET: Supplies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // GET: Supplies/Create
        public ActionResult Create()
        {
            ViewBag.materialID = new SelectList(db.Raw_Material, "materialID", "materialName");
            ViewBag.vendorID = new SelectList(db.Vendors, "vendorID", "vendorName");
            return View();
        }

        // POST: Supplies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "supplyUnitPrice,supplyID,vendorID,materialID")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Supplies.Add(supply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.materialID = new SelectList(db.Raw_Material, "materialID", "materialName", supply.materialID);
            ViewBag.vendorID = new SelectList(db.Vendors, "vendorID", "vendorName", supply.vendorID);
            return View(supply);
        }

        // GET: Supplies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            ViewBag.materialID = new SelectList(db.Raw_Material, "materialID", "materialName", supply.materialID);
            ViewBag.vendorID = new SelectList(db.Vendors, "vendorID", "vendorName", supply.vendorID);
            return View(supply);
        }

        // POST: Supplies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "supplyUnitPrice,supplyID,vendorID,materialID")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.materialID = new SelectList(db.Raw_Material, "materialID", "materialName", supply.materialID);
            ViewBag.vendorID = new SelectList(db.Vendors, "vendorID", "vendorName", supply.vendorID);
            return View(supply);
        }

        // GET: Supplies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.Supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Supply supply = db.Supplies.Find(id);
            db.Supplies.Remove(supply);
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
