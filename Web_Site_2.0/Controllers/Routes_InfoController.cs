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
    public class Routes_InfoController : Controller
    {
        private TransportEntities db = new TransportEntities();

        // GET: Routes_Info
        public ActionResult Index()
        {
            return View(db.Routes_Info.ToList());
        }

        // GET: Routes_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routes_Info routes_Info = db.Routes_Info.Find(id);
            if (routes_Info == null)
            {
                return HttpNotFound();
            }
            return View(routes_Info);
        }

        // GET: Routes_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Routes_Info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteID,Route_Location,Route_District")] Routes_Info routes_Info)
        {
            if (ModelState.IsValid)
            {
                db.Routes_Info.Add(routes_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(routes_Info);
        }

        // GET: Routes_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routes_Info routes_Info = db.Routes_Info.Find(id);
            if (routes_Info == null)
            {
                return HttpNotFound();
            }
            return View(routes_Info);
        }

        // POST: Routes_Info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteID,Route_Location,Route_District")] Routes_Info routes_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(routes_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(routes_Info);
        }

        // GET: Routes_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Routes_Info routes_Info = db.Routes_Info.Find(id);
            if (routes_Info == null)
            {
                return HttpNotFound();
            }
            return View(routes_Info);
        }

        // POST: Routes_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Routes_Info routes_Info = db.Routes_Info.Find(id);
            db.Routes_Info.Remove(routes_Info);
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
