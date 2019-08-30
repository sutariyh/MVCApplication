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
    public class Order_LineController : Controller
    {
        private Entities db = new Entities();

        // GET: Order_Line
        public ActionResult Index()
        {
            var order_Line = db.Order_Line.Include(o => o.Order).Include(o => o.Product);
            return View(order_Line.ToList());
        }

        // GET: Order_Line/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            return View(order_Line);
        }

        // GET: Order_Line/Create
        public ActionResult Create()
        {
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "customerID");
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription");
            return View();
        }

        // POST: Order_Line/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderlineID,orderID,productID,orderQuantity")] Order_Line order_Line)
        {
            if (ModelState.IsValid)
            {
                db.Order_Line.Add(order_Line);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.orderID = new SelectList(db.Orders, "orderID", "customerID", order_Line.orderID);
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription", order_Line.productID);
            return View(order_Line);
        }

        // GET: Order_Line/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "customerID", order_Line.orderID);
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription", order_Line.productID);
            return View(order_Line);
        }

        // POST: Order_Line/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderlineID,orderID,productID,orderQuantity")] Order_Line order_Line)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Line).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.orderID = new SelectList(db.Orders, "orderID", "customerID", order_Line.orderID);
            ViewBag.productID = new SelectList(db.Products, "productID", "productDescription", order_Line.productID);
            return View(order_Line);
        }

        // GET: Order_Line/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Line order_Line = db.Order_Line.Find(id);
            if (order_Line == null)
            {
                return HttpNotFound();
            }
            return View(order_Line);
        }

        // POST: Order_Line/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order_Line order_Line = db.Order_Line.Find(id);
            db.Order_Line.Remove(order_Line);
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
