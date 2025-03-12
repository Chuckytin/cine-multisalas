using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMultisalas.Models
{
    public class Function
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int CinemaId { get; set; }
        public DateTime StartTime { get; set; }

        // Propiedad de solo lectura para el título de la película
        public string FilmTitle { get; set; }

        // Propiedad de solo lectura para el nombre de la sala
        public string CinemaName { get; set; }
    }
}
