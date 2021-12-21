using System;
using System.Collections.Generic;

#nullable disable

namespace FilmaiOutAPI
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
        public int? FkMovies { get; set; }

        public virtual Movie FkMoviesNavigation { get; set; }
        public virtual User FkUsersNavigation { get; set; }
    }
}
