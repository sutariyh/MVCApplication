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
    public class UsController : Controller
    {
        private Entities db = new Entities();

        // GET: Us
        public ActionResult Index()
        {
            var uses = db.Uses.Include(u => u.Product).Include(u => u.Raw_Material);
            return View(uses.ToList());
        }

        // GET: Us/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Us us = db.Uses.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }

        // GET: Us/Create
        public ActionResult Create()
        {
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription");
            ViewBag.materialID = new SelectList(db.Raw_Material, "materialID", "materialName");
            return View();
        }

        // POST: Us/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "usesID,GoesIntoQuantity,productID,materialID")] Us us)
        {
            if (ModelState.IsValid)
            {
                db.Uses.Add(us);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription", us.productID);
            ViewBag.materialID = new SelectList(db.Raw_Material, "materialID", "materialName", us.materialID);
            return View(us);
        }

        // GET: Us/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Us us = db.Uses.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription", us.productID);
            ViewBag.materialID = new SelectList(db.Raw_Material, "materialID", "materialName", us.materialID);
            return View(us);
        }

        // POST: Us/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "usesID,GoesIntoQuantity,productID,materialID")] Us us)
        {
            if (ModelState.IsValid)
            {
                db.Entry(us).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription", us.productID);
            ViewBag.materialID = new SelectList(db.Raw_Material, "materialID", "materialName", us.materialID);
            return View(us);
        }

        // GET: Us/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Us us = db.Uses.Find(id);
            if (us == null)
            {
                return HttpNotFound();
            }
            return View(us);
        }

        // POST: Us/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Us us = db.Uses.Find(id);
            db.Uses.Remove(us);
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
