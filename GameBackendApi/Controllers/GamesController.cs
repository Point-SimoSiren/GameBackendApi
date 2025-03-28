using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameBackendApi.Models; // Models directory

namespace GameBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        // Database connection
        private readonly GameDbContext db = new GameDbContext();

        // Search all games 
        [HttpGet]
        public ActionResult GetGames()
        {
            var games = db.Games.ToList();
            return Ok(games);
        }



        // Adds new game
        [HttpPost]
        public ActionResult AddNewGame([FromBody] Game game)
        {
            try
            {
                db.Games.Add(game);
                db.SaveChanges();
                return Ok($"Added New Game {game.Name}.");
            }

            catch (Exception e)
            {
                return BadRequest("Failed to add new game: Read more: " + e.InnerException);
            }
        }


        // Searches games based on names
        // Search term is provided as a URL parameter (e.g., /api/games/gamename/strategy)
        [HttpGet("gamename/{search}")]
        public ActionResult SearchGames(string search)
        {
            List<Game> games = db.Games.Where(g => g.Name.Contains(search)).ToList();
            return Ok(games);
        }


        // Searches games based on Genre ID
        [HttpGet("genreid/{genreId}")]
        public ActionResult SearchGamesByGenreId(int genreId)
        {
            List<Game> games = db.Games.Where(g => g.GenreId == genreId).ToList();
            return Ok(games);
        }

    }
}
