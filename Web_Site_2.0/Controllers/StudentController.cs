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
    public class StudentController : Controller
    {
        private TransportEntities db = new TransportEntities();

        // GET: Signup
        public ActionResult Index()
        {
            var student_Info = db.Student_Info.Include(s => s.DeptInfo);
            return View(student_Info.ToList());
        }

        // GET: Signup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Info student_Info = db.Student_Info.Find(id);
            if (student_Info == null)
            {
                return HttpNotFound();
            }
            return View(student_Info);
        }

        // GET: Signup/Create
        public ActionResult Create()
        {
            ViewBag.DeptID = new SelectList(db.DeptInfoes, "DeptID", "DeptName");
            return View();
        }

        // POST: Signup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Std_Id,DeptID,Std_FirstName,Std_Semester,Std_Address,Std_No,AdmissionDt,Std_Password")] Student_Info student_Info)
        {
            if (ModelState.IsValid)
            {
                db.Student_Info.Add(student_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptID = new SelectList(db.DeptInfoes, "DeptID", "DeptName", student_Info.DeptID);
            return View(student_Info);
        }

        // GET: Signup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Info student_Info = db.Student_Info.Find(id);
            if (student_Info == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptID = new SelectList(db.DeptInfoes, "DeptID", "DeptName", student_Info.DeptID);
            return View(student_Info);
        }

        // POST: Signup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Std_Id,DeptID,Std_FirstName,Std_Semester,Std_Address,Std_No,AdmissionDt,Std_Password")] Student_Info student_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_Info).State = EntityState.Modified;
                db.SaveChanges();
                return View("~/Views/Home/Student");
            }
            ViewBag.DeptID = new SelectList(db.DeptInfoes, "DeptID", "DeptName", student_Info.DeptID);
            return View(student_Info);
        }

        // GET: Signup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_Info student_Info = db.Student_Info.Find(id);
            if (student_Info == null)
            {
                return HttpNotFound();
            }
            return View(student_Info);
        }

        // POST: Signup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_Info student_Info = db.Student_Info.Find(id);
            db.Student_Info.Remove(student_Info);
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
