using System;

namespace CineMultisalas.Models
{
    public class Function
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int CinemaId { get; set; }
        public DateTime StartTime { get; set; }

        // Propiedades de navegación
        public Film Film { get; set; }
        public Cinema Cinema { get; set; }

        // Propiedades calculadas
        public string FilmTitle => Film?.Title; // Título de la película
        public string CinemaName => Cinema?.Name; // Nombre de la sala
    }
}