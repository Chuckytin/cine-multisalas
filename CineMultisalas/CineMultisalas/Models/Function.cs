using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineMultisalas.Models
{
    internal class Function
    {

        public int FunctionId { get; set; }
        public int FilmId { get; set; } // FK a Film
        public int CinemaId { get; set; } // FK a Cinema
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
