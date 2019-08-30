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
    public class Has_SkillController : Controller
    {
        private Entities db = new Entities();

        // GET: Has_Skill
        public ActionResult Index()
        {
            var has_Skill = db.Has_Skill.Include(h => h.Employee).Include(h => h.Skill);
            return View(has_Skill.ToList());
        }

        // GET: Has_Skill/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Has_Skill has_Skill = db.Has_Skill.Find(id);
            if (has_Skill == null)
            {
                return HttpNotFound();
            }
            return View(has_Skill);
        }

        // GET: Has_Skill/Create
        public ActionResult Create()
        {
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeSupervisor");
            ViewBag.skillID = new SelectList(db.Skills, "skillID", "skillDescription");
            return View();
        }

        // POST: Has_Skill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hashskillID,skillID,employeeID")] Has_Skill has_Skill)
        {
            if (ModelState.IsValid)
            {
                db.Has_Skill.Add(has_Skill);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeSupervisor", has_Skill.employeeID);
            ViewBag.skillID = new SelectList(db.Skills, "skillID", "skillDescription", has_Skill.skillID);
            return View(has_Skill);
        }

        // GET: Has_Skill/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Has_Skill has_Skill = db.Has_Skill.Find(id);
            if (has_Skill == null)
            {
                return HttpNotFound();
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeSupervisor", has_Skill.employeeID);
            ViewBag.skillID = new SelectList(db.Skills, "skillID", "skillDescription", has_Skill.skillID);
            return View(has_Skill);
        }

        // POST: Has_Skill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hashskillID,skillID,employeeID")] Has_Skill has_Skill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(has_Skill).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employeeID = new SelectList(db.Employees, "employeeID", "employeeSupervisor", has_Skill.employeeID);
            ViewBag.skillID = new SelectList(db.Skills, "skillID", "skillDescription", has_Skill.skillID);
            return View(has_Skill);
        }

        // GET: Has_Skill/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Has_Skill has_Skill = db.Has_Skill.Find(id);
            if (has_Skill == null)
            {
                return HttpNotFound();
            }
            return View(has_Skill);
        }

        // POST: Has_Skill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Has_Skill has_Skill = db.Has_Skill.Find(id);
            db.Has_Skill.Remove(has_Skill);
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
