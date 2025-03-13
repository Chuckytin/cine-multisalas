using System;
using System.Collections.Generic;

namespace CineMultisalas.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int FunctionId { get; set; } // ID de la función
        public List<int> SelectedSeats { get; set; } // Lista de asientos seleccionados
    }
}