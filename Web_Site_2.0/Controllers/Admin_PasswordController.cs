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
    public class   Admin_PasswordController : Controller
    {
        private TransportEntities db = new TransportEntities();

        // GET: Admin_Password
        public ActionResult Index()
        {
            return View(db.Admin_Password.ToList());
        }

        // GET: Admin_Password/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_Password admin_Password = db.Admin_Password.Find(id);
            if (admin_Password == null)
            {
                return HttpNotFound();
            }
            return View(admin_Password);
        }

        // GET: Admin_Password/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin_Password/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Admin_Id,Admin_Password1")] Admin_Password admin_Password)
        {
            if (ModelState.IsValid)
            {
                db.Admin_Password.Add(admin_Password);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin_Password);
        }

        // GET: Admin_Password/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_Password admin_Password = db.Admin_Password.Find(id);
            if (admin_Password == null)
            {
                return HttpNotFound();
            }
            return View(admin_Password);
        }

        // POST: Admin_Password/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Admin_Id,Admin_Password1")] Admin_Password admin_Password)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin_Password).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin_Password);
        }

        // GET: Admin_Password/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_Password admin_Password = db.Admin_Password.Find(id);
            if (admin_Password == null)
            {
                return HttpNotFound();
            }
            return View(admin_Password);
        }

        // POST: Admin_Password/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Admin_Password admin_Password = db.Admin_Password.Find(id);
            db.Admin_Password.Remove(admin_Password);
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
