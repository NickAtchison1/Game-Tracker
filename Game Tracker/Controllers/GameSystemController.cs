using Game_Tracker.DataModels;
using Game_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace Game_Tracker.Controllers
{
    public class GameSystemController : ApiController
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();

        [HttpPost]
        public async Task<IHttpActionResult> CreateGameSystem(GameSystem model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.GameSystems.Add(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllGenres()
        {
            return Ok(await _context.GameSystems.ToListAsync());
        }
    }
}
