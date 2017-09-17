using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbstractGymMVC5.Models
{
    public class AppointmentPerson
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}