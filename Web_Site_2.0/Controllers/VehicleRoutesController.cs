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
    public class VehicleRoutesController : Controller
    {
        private TransportEntities db = new TransportEntities();

        // GET: VehicleRoutes
        public ActionResult Index()
        {
            var vehicleRoutes = db.VehicleRoutes.Include(v => v.Routes_Info).Include(v => v.Vehicle_Info);
            return View(vehicleRoutes.ToList());
        }

        // GET: VehicleRoutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleRoute vehicleRoute = db.VehicleRoutes.Find(id);
            if (vehicleRoute == null)
            {
                return HttpNotFound();
            }
            return View(vehicleRoute);
        }

        // GET: VehicleRoutes/Create
        public ActionResult Create()
        {
            ViewBag.RouteID = new SelectList(db.Routes_Info, "RouteID", "Route_Location");
            ViewBag.Van_ID = new SelectList(db.Vehicle_Info, "Van_Id", "Van_Licence");
            return View();
        }

        // POST: VehicleRoutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VR_ID,Van_ID,RouteID,Active")] VehicleRoute vehicleRoute)
        {
            if (ModelState.IsValid)
            {
                db.VehicleRoutes.Add(vehicleRoute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RouteID = new SelectList(db.Routes_Info, "RouteID", "Route_Location", vehicleRoute.RouteID);
            ViewBag.Van_ID = new SelectList(db.Vehicle_Info, "Van_Id", "Van_Licence", vehicleRoute.Van_ID);
            return View(vehicleRoute);
        }

        // GET: VehicleRoutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleRoute vehicleRoute = db.VehicleRoutes.Find(id);
            if (vehicleRoute == null)
            {
                return HttpNotFound();
            }
            ViewBag.RouteID = new SelectList(db.Routes_Info, "RouteID", "Route_Location", vehicleRoute.RouteID);
            ViewBag.Van_ID = new SelectList(db.Vehicle_Info, "Van_Id", "Van_Licence", vehicleRoute.Van_ID);
            return View(vehicleRoute);
        }

        // POST: VehicleRoutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VR_ID,Van_ID,RouteID,Active")] VehicleRoute vehicleRoute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleRoute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RouteID = new SelectList(db.Routes_Info, "RouteID", "Route_Location", vehicleRoute.RouteID);
            ViewBag.Van_ID = new SelectList(db.Vehicle_Info, "Van_Id", "Van_Licence", vehicleRoute.Van_ID);
            return View(vehicleRoute);
        }

        // GET: VehicleRoutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleRoute vehicleRoute = db.VehicleRoutes.Find(id);
            if (vehicleRoute == null)
            {
                return HttpNotFound();
            }
            return View(vehicleRoute);
        }

        // POST: VehicleRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleRoute vehicleRoute = db.VehicleRoutes.Find(id);
            db.VehicleRoutes.Remove(vehicleRoute);
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
