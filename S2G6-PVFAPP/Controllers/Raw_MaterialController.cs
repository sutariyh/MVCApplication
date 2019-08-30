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
    public class Raw_MaterialController : Controller
    {
        private Entities db = new Entities();

        // GET: Raw_Material
        public ActionResult Index()
        {
            return View(db.Raw_Material.ToList());
        }

        // GET: Raw_Material/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Material raw_Material = db.Raw_Material.Find(id);
            if (raw_Material == null)
            {
                return HttpNotFound();
            }
            return View(raw_Material);
        }

        // GET: Raw_Material/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raw_Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "materialID,materialName,materialStandardCost,materialUnitOfCost")] Raw_Material raw_Material)
        {
            if (ModelState.IsValid)
            {
                db.Raw_Material.Add(raw_Material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raw_Material);
        }

        // GET: Raw_Material/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Material raw_Material = db.Raw_Material.Find(id);
            if (raw_Material == null)
            {
                return HttpNotFound();
            }
            return View(raw_Material);
        }

        // POST: Raw_Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "materialID,materialName,materialStandardCost,materialUnitOfCost")] Raw_Material raw_Material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raw_Material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raw_Material);
        }

        // GET: Raw_Material/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raw_Material raw_Material = db.Raw_Material.Find(id);
            if (raw_Material == null)
            {
                return HttpNotFound();
            }
            return View(raw_Material);
        }

        // POST: Raw_Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Raw_Material raw_Material = db.Raw_Material.Find(id);
            db.Raw_Material.Remove(raw_Material);
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
