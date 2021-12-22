using System;
using System.Text.Json.Serialization;

#nullable disable

namespace FilmaiOutAPI.Models.DatabaseModels
{
    public partial class MovieReport
    {
        public int Id { get; set; }
        public DateTime GeneratedAt { get; set; }
        public decimal AverageScore { get; set; }
        public int Views { get; set; }
        public int TotalMovieLists { get; set; }
        public string FkUsers { get; set; }
        public string FkMovies { get; set; }

        [JsonIgnore]
        public virtual Movie FkMoviesNavigation { get; set; }
        [JsonIgnore]
        public virtual User FkUsersNavigation { get; set; }
    }
}
