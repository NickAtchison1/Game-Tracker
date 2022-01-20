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
        public async Task<IHttpActionResult> CreateGameSystem(Genre model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Genres.Add(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        public async Task<IHttpActionResult> GetAllGames()
        {
            return Ok(await _context.Games.ToListAsync());

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


        public async Task<IHttpActionResult> GetAllGamesAboveStarRating([FromUri] int starRating)
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

        [HttpGet]
        public async Task<IHttpActionResult> GetGamesByGameSystem([FromUri] int userInputId)
        {
            List<Game> gamesByGameSystem = await _context.Games.ToListAsync();
            List<GameListItem> gamesByGameSystemList = gamesByGameSystem.Select(r => new GameListItem()
            {
                GameSystem = r.GameSystem.Name,
                GameId = r.GameId,
                Title = r.Title,
                Genre = r.Genre,
            }).ToList();

            foreach (GameListItem game in gamesByGameSystemList)
            {
                if (game.GameSystemId == userInputId)
                {
                    return Ok(game);
                }
            }
            return BadRequest();
        }
    }
}
