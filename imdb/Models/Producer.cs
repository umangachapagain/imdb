using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imdb.Models
{
    public class Producer
    {
        public int ProducerID { get; set; }
        [Display(Name = "Producer")]
        public string Name { get; set; }
        public string Sex { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:Y}", ApplyFormatInEditMode = false)]
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
