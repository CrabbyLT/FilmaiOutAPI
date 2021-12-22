using System;
using System.Text.Json.Serialization;

#nullable disable

namespace FilmaiOutAPI.Models.DatabaseModels
{
    public partial class MovieReview
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public decimal Score { get; set; }
        public DateTime LastEditedAt { get; set; }
        public string FkUsers { get; set; }
        public string FkMovies { get; set; }

        [JsonIgnore]
        public virtual Movie FkMoviesNavigation { get; set; }
        [JsonIgnore]
        public virtual User FkUsersNavigation { get; set; }
    }
}
