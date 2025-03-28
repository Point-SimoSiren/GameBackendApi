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


        // Hakee genret nimen osan perusteella
        // Hakusana annetaan URL parametrina (esim. /api/genres/genrename/strategia)
        [HttpGet("genrename/{search}")]
        public ActionResult SearchGenres(string search)
        {
           List<Genre> genres = db.Genres.Where(g => g.GenreName.Contains(search)).ToList();
            // Täydellinen matchaus
            // List<Genre> genres = db.Genres.Where(g => g.GenreName == search).ToList();

            return Ok(genres);
        }


        // Poistaa genren
        [HttpDelete("{id}")]
       

        public ActionResult DeleteGenre(int id)
        {
            // Haetaan Game objekti kannasta id:n perusteella
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return NotFound($"Genre with id {id} not found."); // <-- string interpolation
            // return NotFound("Genre with id " + id + " not found."); <-- perinteinen
            }
            // Poisto kohdistuu koko objektiin
            db.Genres.Remove(genre);
            db.SaveChanges();
            return Ok($"Genre {genre.GenreName} deleted.");
        }

    }
}
