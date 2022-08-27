using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web_Site_2._0.Models;

namespace Web_Site_2._0.Controllers
{
    public class Van_StudentsController : Controller
    {
        private TransportEntities db = new TransportEntities();

        // GET: Van_Students
        public ActionResult Index()
        {
            var van_Students = db.Van_Students.Include(v => v.Student_Info).Include(v => v.VanDriver_Info);
            return View(van_Students.ToList());
        }

        // GET: Van_Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Van_Students van_Students = db.Van_Students.Find(id);
            if (van_Students == null)
            {
                return HttpNotFound();
            }
            return View(van_Students);
        }

        // GET: Van_Students/Create
        public ActionResult Create()
        {
            ViewBag.Std_Id = new SelectList(db.Student_Info, "Std_Id", "Std_FirstName");
            ViewBag.P_ID = new SelectList(db.VanDriver_Info, "P_ID", "P_ID");
            return View();
        }

        // POST: Van_Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SV_ID,P_ID,Std_Id,Active,JoiningDT,EndingDt")] Van_Students van_Students)
        {
            if (ModelState.IsValid)
            {
                db.Van_Students.Add(van_Students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Std_Id = new SelectList(db.Student_Info, "Std_Id", "Std_FirstName", van_Students.Std_Id);
            ViewBag.P_ID = new SelectList(db.VanDriver_Info, "P_ID", "P_ID", van_Students.P_ID);
            return View(van_Students);
        }

        // GET: Van_Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Van_Students van_Students = db.Van_Students.Find(id);
            if (van_Students == null)
            {
                return HttpNotFound();
            }
            ViewBag.Std_Id = new SelectList(db.Student_Info, "Std_Id", "Std_FirstName", van_Students.Std_Id);
            ViewBag.P_ID = new SelectList(db.VanDriver_Info, "P_ID", "P_ID", van_Students.P_ID);
            return View(van_Students);
        }

        // POST: Van_Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SV_ID,P_ID,Std_Id,Active,JoiningDT,EndingDt")] Van_Students van_Students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(van_Students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Std_Id = new SelectList(db.Student_Info, "Std_Id", "Std_FirstName", van_Students.Std_Id);
            ViewBag.P_ID = new SelectList(db.VanDriver_Info, "P_ID", "P_ID", van_Students.P_ID);
            return View(van_Students);
        }

        // GET: Van_Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Van_Students van_Students = db.Van_Students.Find(id);
            if (van_Students == null)
            {
                return HttpNotFound();
            }
            return View(van_Students);
        }

        // POST: Van_Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Van_Students van_Students = db.Van_Students.Find(id);
            db.Van_Students.Remove(van_Students);
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
