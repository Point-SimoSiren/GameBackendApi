using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GameBackendApi.Models; // Lisätty

namespace GameBackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        // Tietokantayhteys
        private readonly GameDbContext db = new GameDbContext();


        // Hakee kaikki genret
        [HttpGet]
        public ActionResult GetGenres()
        {
            var genres = db.Genres.ToList();

            return Ok(genres);
        }


        // Lisää uuden genren
        [HttpPost]
        public ActionResult AddNewGenre([FromBody] Genre genre)
        {
            db.Genres.Add(genre);
            db.SaveChanges();

            return Ok($"lisätty uusi genre: {genre.GenreName}.");
        }

    }
}
