using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbstractGymMVC5.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string RoomName { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}