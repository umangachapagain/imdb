using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imdb.Models
{
    public class Actor
    {
        public int ActorID { get; set; }
        [Display(Name = "Actor")]
        public string Name { get; set; }
        public string Sex { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:Y}", ApplyFormatInEditMode = false)]
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        
        public ICollection<MovieActor> MovieActors { get; set; }
    }
}
