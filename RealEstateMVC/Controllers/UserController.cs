using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealEstateMVC;
using System.Diagnostics;

namespace RealEstateMVC.Controllers
{
    public class UserController : Controller
    {
        private DBModel db = new DBModel();

        // GET: User
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: User/Register
        public ActionResult Register()
        {
            ViewBag.Current = "Register";

            return View();
        }

        // POST: User/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "user_id,first_name,last_name,city,country,birth_date,gender,email,phone,type,password")] users users)
        {
            Debug.WriteLine("First Name: " + users.first_name);
            Debug.WriteLine("Last Name: " + users.last_name);
            Debug.WriteLine("City: " + users.city);
            Debug.WriteLine("Country: " + users.country);
            Debug.WriteLine("DOB: " + users.birth_date);

            Debug.WriteLine("Phone: " + users.phone);
            Debug.WriteLine("Type: " + users.type);

            Debug.WriteLine("Email: " + users.email);
            Debug.WriteLine("Password: " + users.password);

            if (ModelState.IsValid)
            {
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(users);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,first_name,last_name,city,country,birth_date,gender,email,phone,type,password")] users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View(users);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users users = db.users.Find(id);
            db.users.Remove(users);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            ViewBag.Current = "Login";

            return View();
        }

        [HttpPost]
        public ActionResult Login(users User)
        {
            users login = null;

            try
            {
                login = db.users.Where(u => u.email == User.email && u.password == User.password).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (login != null)
            {
                Session["User"] = (users)login;

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ModelState.AddModelError("", "Email and/or password is invalid!");
            }

            return View(User);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Request.Cookies.Clear();

            HttpContext.Session["User"] = null;

            return RedirectToAction("Index", "Home", new { area = "" });
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
