using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieConsoleApp.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }


        //Navigation
        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
