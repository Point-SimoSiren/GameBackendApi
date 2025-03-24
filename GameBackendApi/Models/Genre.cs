using System;
using System.Collections.Generic;

namespace GameBackendApi.Models;

public partial class Genre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
