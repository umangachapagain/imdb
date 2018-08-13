using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using imdb.Models;

namespace imdb.Views
{
    public class MoviesxController : Controller
    {
        private readonly imdbContext _context;

        public MoviesxController(imdbContext context)
        {
            _context = context;
        }

        // GET: Moviesx
        public async Task<IActionResult> Index()
        {
            var imdbContext = _context.Movie
                 .Include(m => m.Producer)
                 .Include(m => m.MovieActors)
                     .ThenInclude(m => m.Actor);
            return View(await imdbContext.ToListAsync());
        }

        // GET: Moviesx/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var imdbContext = _context.Movie
             .Include(m => m.Producer)
             .Include(m => m.MovieActors)
                 .ThenInclude(m => m.Actor)
             .FirstOrDefaultAsync(m => m.MovieID == id);
            if (imdbContext == null)
            {
                return NotFound();
            }
            
            return View(await imdbContext);
        }

        // GET: Moviesx/Create
        public IActionResult Create()
        {
            ViewData["ProducerName"] = new SelectList(_context.Producer, "Name", "Name");
            ViewData["ActorName"] = new SelectList(_context.Actor, "Name", "Name");
            return View();
        }

        // POST: Moviesx/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MAPModel mAP)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie();
                movie.Title = mAP.Movie.Title;
                movie.ReleaseYear = mAP.Movie.ReleaseYear;
                movie.Plot = mAP.Movie.Plot;
                movie.Poster = mAP.Movie.Poster;
                movie.ProducerID = _context.Producer.FirstOrDefault(m => m.Name == mAP.Producer.Name).ProducerID;
                _context.Movie.Add(movie);
                _context.SaveChanges();
                
                var movieActor = new MovieActor();
                movieActor.MovieID = movie.MovieID;
                movieActor.ActorID = _context.Actor.FirstOrDefault(m => m.Name == mAP.Actor.Name).ActorID;
                _context.MovieActor.Add(movieActor);
                              
                          
                

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProducerName"] = new SelectList(_context.Producer, "ProducerName", "ProducerName", mAP.Producer.Name);
            ViewData["ActorName"] = new SelectList(_context.Actor, "Name", "Name", mAP.Actor.Name);
            return View(mAP);
        }

        // GET: Moviesx/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           // var movie = await _context.Movie.FindAsync(id);
            var movie =await _context.Movie
                  .Include(m => m.Producer)
                  .Include(m => m.MovieActors)
                      .ThenInclude(m => m.Actor)
                   .FirstOrDefaultAsync(m => m.MovieID == id);
            
            if (movie == null)
            {
                return NotFound();
            }
            
            ViewData["ProducerName"] = new SelectList(_context.Producer, "ProducerID", "Name");
            ViewData["ActorName"] = new SelectList(_context.Actor, "ActorID", "Name");
            return View(movie);
        }

        // POST: Moviesx/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieID,Title,ReleaseYear,Plot,Poster,ProducerID,ActorID")] MAPModel  movie)
        {
            if (id != movie.Movie.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Movie.Update(movie.Movie);
                    _context.MovieActor.Update(movie.MovieActor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Movie.MovieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Moviesx", new { area = "" });
            }
            ViewData["ProducerName"] = new SelectList(_context.Producer, "ProducerID", "Name", movie.Producer.Name);
            return View(movie);
        }

        // GET: Moviesx/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .Include(m => m.Producer)
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Moviesx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.MovieID == id);
        }
    }
}
