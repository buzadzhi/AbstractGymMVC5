using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbstractGymMVC5.DAL;
using AbstractGymMVC5.Models;

namespace AbstractGymMVC5.Controllers
{
    public class AppointmentPersonsController : Controller
    {
        private AppointmentContext db = new AppointmentContext();

        // GET: AppointmentPersons
        public ActionResult Index()
        {
            return View(db.AppointmentPersons.ToList());
        }

        // GET: AppointmentPersons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentPerson appointmentPerson = db.AppointmentPersons.Find(id);
            if (appointmentPerson == null)
            {
                return HttpNotFound();
            }
            return View(appointmentPerson);
        }

        // GET: AppointmentPersons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentPersons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName")] AppointmentPerson appointmentPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.AppointmentPersons.Add(appointmentPerson);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "We were unable to save changes. Please try again or contact the administrator.");
            }


            return View(appointmentPerson);
        }

        // GET: AppointmentPersons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppointmentPerson appointmentPerson = db.AppointmentPersons.Find(id);
            if (appointmentPerson == null)
            {
                return HttpNotFound();
            }
            return View(appointmentPerson);
        }

        // POST: AppointmentPersons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName")] AppointmentPerson appointmentPerson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointmentPerson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointmentPerson);
        }

        // GET: AppointmentPersons/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError.GetValueOrDefault())
            { 
                ViewBag.ErrorMessage = "Cannot delete. Try again or contact the administrator.";
            }

            AppointmentPerson appointmentPerson = db.AppointmentPersons.Find(id);
            if (appointmentPerson == null)
            {
                return HttpNotFound();
            }
            return View(appointmentPerson);
        }

        // POST: AppointmentPersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                AppointmentPerson appointmentPerson = db.AppointmentPersons.Find(id);
                db.AppointmentPersons.Remove(appointmentPerson);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

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
