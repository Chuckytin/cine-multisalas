using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMultisalas.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; } // FK a User
        public int FunctionId { get; set; } // FK a Function
        public int Seats { get; set; } // Número de asientos reservados

    }
}
