using Game_Tracker.DataModels;
using Game_Tracker.DisplayModels;
using Game_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Game_Tracker.Controllers
{
    public class GameController : ApiController
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();

        public async Task<IHttpActionResult> GetAllGamesByWordInTitle(string word)
        {
            List<Game> games = await _context.Games.ToListAsync();

            List<GameListItem> list = games.Select(
                g => new GameListItem()
                {
                    Title = g.Title,
                    Genre = g.Genre,
                    StarRating = g.StarRating
                }
            ).ToList();

            foreach (GameListItem game in list)
            {
                if (game.Title.Contains(word))
                {
                    return Ok(game);
                }
            }

            return BadRequest();
        }


        public async Task<IHttpActionResult> GetAllGamesAboveStarRating([FromUri]int starRating)
        {
            List<Game> games = await _context.Games.ToListAsync();

            List<GameListItem> list = games.Select(
                g => new GameListItem()
                {
                    Title = g.Title,
                    Genre = g.Genre,
                    StarRating = g.StarRating
                }
            ).ToList();

            foreach (GameListItem game in list)
            {
                if (game.StarRating >= starRating)
                {
                    return Ok(game);
                }
            }

            return BadRequest();
        }
        private readonly ApplicationDBContext _context = new ApplicationDBContext();

        [HttpGet]
        public async Task<IHttpActionResult> GetGamesAlphabetically()
        {
            List<Game> games = await _context.Games.ToListAsync();
            List<GameListItem> gameList = games.Select(g => new GameListItem()
            {                
                Name = g.Title

            }).ToList();

            IEnumerable<GameListItem> result = gameList.OrderBy(g => g.Name).ToList();

            return Ok(result);


        }
    }
}
