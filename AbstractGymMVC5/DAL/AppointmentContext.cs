using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AbstractGymMVC5.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AbstractGymMVC5.DAL
{
    public class AppointmentContext : DbContext 
    {
        public AppointmentContext() : base ("AppointmentContext")
        { }

        public DbSet<AppointmentPerson> AppointmentPersons { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<AppointmentPerson>().ToTable("AppointmentPerson");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}