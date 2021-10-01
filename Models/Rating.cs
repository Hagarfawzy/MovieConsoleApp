using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieConsoleApp.Models
{
    public class Rating
    {
        public int MovieId { get; set; }
        public int ReviewerId { get; set; }
        public int Stars { get; set; }
        public int NumOfRating { get; set; }


        //Navigation
        public Movie Movie { get; set; }
        public Reviewer Reviewer { get; set; }
    }
}
