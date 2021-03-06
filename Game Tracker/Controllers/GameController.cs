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

        [HttpGet]
        [Route("api/GetAllGames")]
        public async Task<IHttpActionResult> GetAllGames()
        {
            return Ok(await _context.Games.Select(g=> new GetAllGamesDetails
            { 
                Title = g.Title,
                GameSystemName = g.GameSystem.Name, 
                Rating = g.ESRBRating.ToString(), 
                StarRating = g.StarRating

            }).ToListAsync());

        }
        [HttpGet]
        [Route("api/GetAllGamesByWordInTitle/{word}")]
        public async Task<IHttpActionResult> GetAllGamesByWordInTitle([FromUri] string word)
        {
            List<Game> games = await _context.Games.ToListAsync();

            List<GameListItem> list = games.Select(
                g => new GameListItem()
                {
                    Title = g.Title,
                    Genre = g.Genre.Name,
                    StarRating = g.StarRating
                }
            ).Where(x => x.Title.ToLower().Contains(word.ToLower())).ToList();

          
            return Ok(list);

         
        }

        [HttpGet]
        [Route("api/GetAllGamesAboveStarRating/{starRating:int}")]
        public async Task<IHttpActionResult> GetAllGamesAboveStarRating([FromUri] int starRating)
        {
         
            List<Game> games = await _context.Games.ToListAsync();

            List<GameListItem> list = games.Select(
                g => new GameListItem()
                {
                    Title = g.Title,
                    StarRating = g.StarRating
                }
            ).Where(x => x.StarRating >= starRating).ToList();
            return Ok(list);

         
        }

        [HttpGet]
        [Route("api/GetGamesAlphabetically")]
        public async Task<IHttpActionResult> GetGamesAlphabetically()
        {
            List<Game> games = await _context.Games.ToListAsync();
            List<GameListTitles> gameList = games.Select(g => new GameListTitles()
            {
                Title = g.Title,                

            }).OrderBy(g => g.Title).ToList();

            return Ok(gameList);
        }

        [HttpGet]
        [Route("api/GetGamesByGameSystem/{userInputId:int}")]
        public async Task<IHttpActionResult> GetGamesByGameSystem([FromUri] int userInputId)
        {
            List<Game> gamesByGameSystem = await _context.Games.ToListAsync();
            List<GameListItem> gamesByGameSystemList = gamesByGameSystem.Select(r => new GameListItem()
            {
                GameSystemId = r.GameSystemId,
                GameSystem = r.GameSystem.Name,
                GameId = r.GameId,
                Title = r.Title,
                Genre = r.Genre.Name,
            }).Where(x => x.GameSystemId == userInputId).ToList();
            return Ok(gamesByGameSystemList);

           
        }
    }
}
