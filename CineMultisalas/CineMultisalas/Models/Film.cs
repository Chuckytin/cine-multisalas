using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMultisalas.Models
{
    internal class Film
    {

        public int FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } // En minutos
        public string Genre { get; set; }

    }
}
