#nullable disable

namespace FilmaiOutAPI.Models.DatabaseModels
{
    public partial class ListMovie
    {
        public int Id { get; set; }
        public int? FkMovieLists { get; set; }
        public string FkMovies { get; set; }

        public virtual MovieList FkMovieListsNavigation { get; set; }
        public virtual Movie FkMoviesNavigation { get; set; }
    }
}
