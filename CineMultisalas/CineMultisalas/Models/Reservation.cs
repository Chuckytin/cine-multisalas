using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMultisalas.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FunctionId { get; set; }
        public List<int> SelectedSeats { get; set; } // Lista de asientos seleccionados
    }
}
