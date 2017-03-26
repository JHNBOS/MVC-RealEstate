using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealEstateMVC;

namespace RealEstateMVC.Controllers
{
    public class PropertyController : Controller
    {
        private DBModel db = new DBModel();

        // GET: Property
        public ActionResult Index()
        {
            ViewBag.Properties = db.properties.ToList();
            ViewBag.CurrentUser = (users)Session["User"];
            return View();
        }

        // GET: Property/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            properties property = db.properties.Find(id);
            if (property == null)
            {
                return HttpNotFound();
            }
            return View(property);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Property/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "property_id,type,city,country,built_year,number_of_rooms,area_size,price,image, address, postal, owned_by")] properties properties)
        {
            if (ModelState.IsValid)
            {
                db.properties.Add(properties);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(properties);
        }

        // GET: Property/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            properties properties = db.properties.Find(id);
            if (properties == null)
            {
                return HttpNotFound();
            }
            return View(properties);
        }

        // POST: Property/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "property_id,type,city,country,built_year,number_of_rooms,area_size,price,image, address, postal, owned_by")] properties properties)
        {
            if (ModelState.IsValid)
            {
                db.Entry(properties).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(properties);
        }

        // GET: Property/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            properties properties = db.properties.Find(id);
            if (properties == null)
            {
                return HttpNotFound();
            }
            return View(properties);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            properties properties = db.properties.Find(id);
            db.properties.Remove(properties);
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
