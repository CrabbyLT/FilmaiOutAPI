using System;
using System.Collections.Generic;

#nullable disable

namespace FilmaiOutAPI
{
    public partial class MovieReport
    {
        public int Id { get; set; }
        public DateTime GeneratedAt { get; set; }
        public decimal AverageScore { get; set; }
        public int Views { get; set; }
        public int TotalMovieLists { get; set; }
        public string FkUsers { get; set; }
        public int? FkMovies { get; set; }

        public virtual Movie FkMoviesNavigation { get; set; }
        public virtual User FkUsersNavigation { get; set; }
    }
}
