using Game_Tracker.DataModels;
using Game_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace Game_Tracker.Controllers
{
    public class GenreController : ApiController
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();

        [HttpPost]
        public async Task<IHttpActionResult> CreateGameSystem(Genre model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Genres.Add(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetGenres()
        {
            return Ok(_context.Genres.ToListAsync());            
        }
    }
}
