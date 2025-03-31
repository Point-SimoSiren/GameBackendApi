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


        // Deletes game with the given ID
        [HttpDelete("{id}")]
        public ActionResult DeleteGame(int id)
        {
            Game? game = db.Games.Find(id);
            if (game == null)
            {
                return NotFound($"Game with id {id} not found for deletion.");
            }
            db.Games.Remove(game);
            db.SaveChanges();
            return Ok($"Game {game.Name} deleted succesfully!");
        }


        // Pelin muokkaus
        [HttpPut("{id}")]
        public ActionResult EditGame(int id, [FromBody] Game editedGame)
        {
            Game? oldGame = db.Games.Find(id);
            if (oldGame == null)
            {
                return NotFound($"Game with id {id} not found for editing.");
            }

            //oldGame.Name = editedGame.Name;
            //oldGame.GenreId = editedGame.GenreId;
            //oldGame.Description = editedGame.Description;
            //oldGame.Downloads = editedGame.Downloads;
            //oldGame.Stars = editedGame.Stars;
            //oldGame.ReleaseDate = editedGame.ReleaseDate;

            db.Entry(oldGame).CurrentValues.SetValues(editedGame);

            db.SaveChanges();

            return Ok($"Game {editedGame.Name} edited succesfully!");

        }
     }
}
