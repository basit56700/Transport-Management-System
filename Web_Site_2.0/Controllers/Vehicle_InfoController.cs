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
    public class Vehicle_InfoController : Controller
    {
        private TransportEntities db = new TransportEntities();

        // GET: Vehicle_Info
        public ActionResult Index()
        {
            return View(db.Vehicle_Info.ToList());
        }

        // GET: Vehicle_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle_Info vehicle_Info = db.Vehicle_Info.Find(id);
            if (vehicle_Info == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_Info);
        }

        // GET: Vehicle_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicle_Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Van_Id,Van_Licence,Capacity,Active")] Vehicle_Info vehicle_Info)
        {
            if (ModelState.IsValid)
            {
                db.Vehicle_Info.Add(vehicle_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle_Info);
        }

        // GET: Vehicle_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle_Info vehicle_Info = db.Vehicle_Info.Find(id);
            if (vehicle_Info == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_Info);
        }

        // POST: Vehicle_Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Van_Id,Van_Licence,Capacity,Active")] Vehicle_Info vehicle_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle_Info);
        }

        // GET: Vehicle_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle_Info vehicle_Info = db.Vehicle_Info.Find(id);
            if (vehicle_Info == null)
            {
                return HttpNotFound();
            }
            return View(vehicle_Info);
        }

        // POST: Vehicle_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle_Info vehicle_Info = db.Vehicle_Info.Find(id);
            db.Vehicle_Info.Remove(vehicle_Info);
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
