#nullable disable

using System.Text.Json.Serialization;

namespace FilmaiOutAPI.Models.DatabaseModels
{
    public partial class ListMovie
    {
        public int Id { get; set; }
        public int? FkMovieLists { get; set; }
        public string FkMovies { get; set; }

        [JsonIgnore]
        public virtual MovieList FkMovieListsNavigation { get; set; }
        [JsonIgnore]
        public virtual Movie FkMoviesNavigation { get; set; }
    }
}
