using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AbstractGymMVC5.Models;

namespace AbstractGymMVC5.DAL
{
    public class AppointmentInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AppointmentContext>
    {
        protected override void Seed(AppointmentContext context)
        {
            var appointmentpersons = new AppointmentPerson[]
            {
                new AppointmentPerson { FirstName="John", LastName="Smith"},
                new AppointmentPerson { FirstName="Ann", LastName="Willson"},
                new AppointmentPerson { FirstName="Jane", LastName="Air"},
                new AppointmentPerson { FirstName="Ariya", LastName="Stark"},
                new AppointmentPerson { FirstName="Dan", LastName="Black"}
            };

            foreach(AppointmentPerson a in appointmentpersons)
            {
                context.AppointmentPersons.Add(a);
            }
            
            context.SaveChanges();


            var rooms = new Room[]
            {
                new Room { RoomName="B123"},
                new Room { RoomName="G12"},
                new Room { RoomName="L41"},
                new Room { RoomName="1212"}
            };

            foreach(Room r in rooms)
            {
                context.Rooms.Add(r);
            }

            context.SaveChanges();


         

            var users = new User[]
            {
                new User { FirstName="Mike", LastName="Taranti", email="taranti@gmail.com", Gender="m", DOB=DateTime.Parse("1991-11-11")},
                new User { FirstName="Nil", LastName="Argento", email="argento@gmail.com", Gender="m", DOB=DateTime.Parse("1987-10-10")},
                new User { FirstName="Michael", LastName="Basmati", email="basmati@gmail.com", Gender="m", DOB=DateTime.Parse("1977-09-09")},
                new User { FirstName="Jessika", LastName="Alp", email="alp@gmail.com", Gender="f", DOB=DateTime.Parse("1967-08-08")},
                new User { FirstName="Amanda", LastName="Wane", email="wane@gmail.com", Gender="f", DOB=DateTime.Parse("1955-07-07")}

            };

            foreach (User u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();


            var appointments = new List<Appointment>
            {
                new Appointment { AppointmentPersonID=appointmentpersons.Single( i => i.LastName == "Smith").ID, RoomID=rooms.Single( i => i.RoomName == "B123").ID, AppointmentDate=DateTime.Parse("2017-01-12"), AppointmentReason="bla", UserID=users.Single( i => i.LastName == "Taranti").ID },
                new Appointment { AppointmentPersonID=appointmentpersons.Single( i => i.LastName == "Willson").ID, RoomID=rooms.Single( i => i.RoomName == "G12").ID, AppointmentDate=DateTime.Parse("2017-01-01"), AppointmentReason="got sick", UserID=users.Single( i => i.LastName == "Argento").ID},
                new Appointment { AppointmentPersonID=appointmentpersons.Single( i => i.LastName == "Air").ID, RoomID=rooms.Single( i => i.RoomName == "B123").ID, AppointmentDate=DateTime.Parse("2017-12-07"), AppointmentReason="yoyo", UserID=users.Single( i => i.LastName == "Basmati").ID},
                new Appointment { AppointmentPersonID=appointmentpersons.Single( i => i.LastName == "Stark").ID, RoomID=rooms.Single( i => i.RoomName == "L41").ID, AppointmentDate=DateTime.Parse("2017-05-11"), AppointmentReason="bla", UserID=users.Single( i => i.LastName == "Alp").ID},
                new Appointment { AppointmentPersonID=appointmentpersons.Single( i => i.LastName == "Black").ID, RoomID=rooms.Single( i => i.RoomName == "1212").ID, AppointmentDate=DateTime.Parse("2017-08-01"), AppointmentReason="12313123", UserID=users.Single( i => i.LastName == "Wane").ID}

            };



            foreach (Appointment ap in appointments)
            {
                var appointmentDataBase = context.Appointments.Where(
                    a =>
                        a.AppointmentPerson.ID == ap.AppointmentPersonID && a.User.ID == ap.UserID &&
                        a.Room.ID == ap.RoomID).SingleOrDefault();
                
                if(appointmentDataBase == null)
                {
                    context.Appointments.Add(ap);
                }
            }


        appointments.ForEach(s => context.Appointments.Add(s));
            context.SaveChanges();

        }
        
    }
}