using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbstractGymMVC5.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; } //test
        public int RoomID { get; set; }
        public int AppointmentPersonID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentReason { get; set; }
    }
}