using System;
using System.Collections.Generic;

namespace GameBackendApi.Models;

public partial class Game
{
    public int GameId { get; set; }

    public string Name { get; set; } = null!;

    public int GenreId { get; set; }

    public string? Description { get; set; }

    public int Downloads { get; set; }

    public decimal Stars { get; set; }

    public DateOnly ReleaseDate { get; set; }

    //public virtual Genre Genre { get; set; } = null!;
}
