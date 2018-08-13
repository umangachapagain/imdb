using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace imdb.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Release Year")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:Y}", ApplyFormatInEditMode = false)]
        public DateTime ReleaseYear { get; set; }
        [Required]
        public string Plot { get; set; }
        [Required]
        public string Poster { get; set; }
        public int ProducerID { get; set; }
        public Producer Producer { get; set; }

        public ICollection<MovieActor> MovieActors { get; set;}
    }
}
