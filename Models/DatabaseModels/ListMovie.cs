#nullable disable

namespace FilmaiOutAPI
{
    public partial class ListMovie
    {
        public int Id { get; set; }
        public int? FkMovieLists { get; set; }
        public int? FkMovies { get; set; }

        public virtual MovieList FkMovieListsNavigation { get; set; }
        public virtual Movie FkMoviesNavigation { get; set; }
    }
}
