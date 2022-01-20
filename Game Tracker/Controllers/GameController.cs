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

        [HttpPost]
        public async Task<IHttpActionResult> CreateGame(GameCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Game game = new Game()
            {
                Title = model.Title,
                ReleaseDate = model.ReleaseDate,
                Publisher = model.Publisher,
                ESRBRating = model.ESRBRating,
                StarRating = model.StarRating,
                GenreId = model.GenreId,
                GameSystemId = model.GameSystemId,


            };
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return Ok();
        }
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

        [HttpGet]
        public async Task<IHttpActionResult> GetGamesAlphabetically()
        {
            List<Game> games = await _context.Games.ToListAsync();
            List<GameListItem> gameList = games.Select(g => new GameListItem()
            {                
                Title = g.Title

            }).ToList();

            IEnumerable<GameListItem> result = gameList.OrderBy(g => g.Title).ToList();

            return Ok(result);


        }
    }
}
