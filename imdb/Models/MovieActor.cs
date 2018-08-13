using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace imdb.Models
{
    public class MovieActor
    {
        public int MovieActorID { get; set; }

        public int ActorID { get; set; }
        public Actor Actor { get; set; }

        public int MovieID { get; set; }
        public Movie Movie { get; set; }
    }
   
}
