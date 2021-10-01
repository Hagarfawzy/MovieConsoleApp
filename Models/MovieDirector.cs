using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieConsoleApp.Models
{
    public class MovieDirector
    {
        public int DirectorId { get; set; }
        public int MovieId { get; set; }


        //Navigation
        public Movie Movie { get; set; }
        public Director Director { get; set; }
    }
}
