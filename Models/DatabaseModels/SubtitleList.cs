#nullable disable

using System.Text.Json.Serialization;

namespace FilmaiOutAPI.Models.DatabaseModels
{
    public partial class SubtitleList
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string FkUsers { get; set; }
        public string FkMovies { get; set; }

        [JsonIgnore]
        public virtual Movie FkMoviesNavigation { get; set; }
        [JsonIgnore]
        public virtual User FkUsersNavigation { get; set; }
    }
}
