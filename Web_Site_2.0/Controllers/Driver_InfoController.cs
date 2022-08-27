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
    public class Driver_InfoController : Controller
    {
        private TransportEntities db = new TransportEntities();

        // GET: Driver_Info
        public ActionResult Index()
        {
            return View(db.Driver_Info.ToList());
        }

        // GET: Driver_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver_Info driver_Info = db.Driver_Info.Find(id);
            if (driver_Info == null)
            {
                return HttpNotFound();
            }
            return View(driver_Info);
        }

        // GET: Driver_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Driver_Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Driver_Id,D_FirstName,Driver_No,D_Cnic,Active")] Driver_Info driver_Info)
        {
            if (ModelState.IsValid)
            {
                db.Driver_Info.Add(driver_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driver_Info);
        }

        // GET: Driver_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver_Info driver_Info = db.Driver_Info.Find(id);
            if (driver_Info == null)
            {
                return HttpNotFound();
            }
            return View(driver_Info);
        }

        // POST: Driver_Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Driver_Id,D_FirstName,Driver_No,D_Cnic,Active")] Driver_Info driver_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driver_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driver_Info);
        }

        // GET: Driver_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Driver_Info driver_Info = db.Driver_Info.Find(id);
            if (driver_Info == null)
            {
                return HttpNotFound();
            }
            return View(driver_Info);
        }

        // POST: Driver_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Driver_Info driver_Info = db.Driver_Info.Find(id);
            db.Driver_Info.Remove(driver_Info);
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
