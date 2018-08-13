using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using imdb.Models;

namespace imdb.Models
{
    public class imdbContext : DbContext
    {
        public imdbContext (DbContextOptions<imdbContext> options)
            : base(options)
        {
        }

        public DbSet<imdb.Models.Movie> Movie { get; set; }

        public DbSet<imdb.Models.Producer> Producer { get; set; }

        public DbSet<imdb.Models.Actor> Actor { get; set; }

        public DbSet<imdb.Models.MovieActor> MovieActor { get; set; }

        public DbSet<imdb.Models.MAPModel> MAPModel { get; set; }
    }
}
