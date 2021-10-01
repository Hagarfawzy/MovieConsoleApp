using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieConsoleApp.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }


        //Navigation
        public ICollection<Rating> Ratings { get; set; }
    }
}
