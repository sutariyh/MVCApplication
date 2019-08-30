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
    public class Product_LineController : Controller
    {
        private Entities db = new Entities();

        // GET: Product_Line
        public ActionResult Index()
        {
            return View(db.Product_Line.ToList());
        }

        // GET: Product_Line/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Line product_Line = db.Product_Line.Find(id);
            if (product_Line == null)
            {
                return HttpNotFound();
            }
            return View(product_Line);
        }

        // GET: Product_Line/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product_Line/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productlineID,productlineName")] Product_Line product_Line)
        {
            if (ModelState.IsValid)
            {
                db.Product_Line.Add(product_Line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product_Line);
        }

        // GET: Product_Line/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Line product_Line = db.Product_Line.Find(id);
            if (product_Line == null)
            {
                return HttpNotFound();
            }
            return View(product_Line);
        }

        // POST: Product_Line/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productlineID,productlineName")] Product_Line product_Line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_Line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product_Line);
        }

        // GET: Product_Line/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_Line product_Line = db.Product_Line.Find(id);
            if (product_Line == null)
            {
                return HttpNotFound();
            }
            return View(product_Line);
        }

        // POST: Product_Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product_Line product_Line = db.Product_Line.Find(id);
            db.Product_Line.Remove(product_Line);
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
