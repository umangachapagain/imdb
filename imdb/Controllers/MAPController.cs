using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using imdb.Models;


namespace imdb.Controllers
{
    public class MAPController : Controller
    {
        private readonly imdbContext _context;

        public MAPController(imdbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            MAPModel model = new MAPModel();
            
            return View(model);
        }
    }
}