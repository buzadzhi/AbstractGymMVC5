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
            var appointmentpersons = new List<AppointmentPerson>
            {
                new AppointmentPerson { FirstName="John", LastName="Smith"},
                new AppointmentPerson { FirstName="Ann", LastName="Willson"},
                new AppointmentPerson { FirstName="Jane", LastName="Air"},
                new AppointmentPerson { FirstName="Ariya", LastName="Stark"},
                new AppointmentPerson { FirstName="Dan", LastName="Black"}
            };

            appointmentpersons.ForEach(s => context.AppointmentPersons.Add(s));
            context.SaveChanges();

            var rooms = new List<Room>
            {
                new Room { RoomName="B123"},
                new Room { RoomName="G12"},
                new Room { RoomName="L41"},
                new Room { RoomName="1212"}
            };

            rooms.ForEach(s => context.Rooms.Add(s));
            context.SaveChanges();


            var appointments = new List<Appointment>
            {
                new Appointment { AppointmentPersonID=1, RoomID=2, AppointmentDate=DateTime.Parse("2017-01-12"), AppointmentReason="bla" },
                new Appointment { AppointmentPersonID=3, RoomID=1, AppointmentDate=DateTime.Parse("2017-01-01"), AppointmentReason="got sick"},
                new Appointment { AppointmentPersonID=3, RoomID=3, AppointmentDate=DateTime.Parse("2017-12-07"), AppointmentReason="yoyo"},
                new Appointment { AppointmentPersonID=1, RoomID=4, AppointmentDate=DateTime.Parse("2017-05-11"), AppointmentReason="bla"},
                new Appointment { AppointmentPersonID=2, RoomID=2, AppointmentDate=DateTime.Parse("2017-08-01"), AppointmentReason="12313123"},
                new Appointment { AppointmentPersonID=4, RoomID=1, AppointmentDate=DateTime.Parse("2017-11-01"), AppointmentReason="aloha"},
                new Appointment { AppointmentPersonID=2, RoomID=3, AppointmentDate=DateTime.Parse("2017-01-06"), AppointmentReason="newnwnewnwe"},
                new Appointment { AppointmentPersonID=5, RoomID=1, AppointmentDate=DateTime.Parse("2017-01-03"), AppointmentReason="lorem ipsum"},

            };

            appointments.ForEach(s => context.Appointments.Add(s));
            context.SaveChanges();
        }
        
    }
}