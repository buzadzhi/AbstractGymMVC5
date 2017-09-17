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
    public class AppointmentsController : Controller
    {
        private AppointmentContext db = new AppointmentContext();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.AppointmentPerson).Include(a => a.Room).Include(a => a.User);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentPersonID = new SelectList(db.AppointmentPersons, "ID", "FirstName");
            ViewBag.RoomID = new SelectList(db.Rooms, "ID", "RoomName");
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentID,RoomID,AppointmentPersonID,AppointmentDate,AppointmentReason,UserID")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentPersonID = new SelectList(db.AppointmentPersons, "ID", "FirstName", appointment.AppointmentPersonID);
            ViewBag.RoomID = new SelectList(db.Rooms, "ID", "RoomName", appointment.RoomID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", appointment.UserID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentPersonID = new SelectList(db.AppointmentPersons, "ID", "FirstName", appointment.AppointmentPersonID);
            ViewBag.RoomID = new SelectList(db.Rooms, "ID", "RoomName", appointment.RoomID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", appointment.UserID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentID,RoomID,AppointmentPersonID,AppointmentDate,AppointmentReason,UserID")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentPersonID = new SelectList(db.AppointmentPersons, "ID", "FirstName", appointment.AppointmentPersonID);
            ViewBag.RoomID = new SelectList(db.Rooms, "ID", "RoomName", appointment.RoomID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", appointment.UserID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
