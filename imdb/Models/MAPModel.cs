using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace imdb.Models
{
    public class MAPModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MAPModelID { get; set; }
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }
        public Producer Producer { get; set; }
        public MovieActor MovieActor { get; set; }
    }
}
