using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace FilmaiOutAPI
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            MovieLists = new HashSet<MovieList>();
            MovieReports = new HashSet<MovieReport>();
            MovieReviews = new HashSet<MovieReview>();
            Posts = new HashSet<Post>();
            SubtitleLists = new HashSet<SubtitleList>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public short Age { get; set; }
        public bool Administrator { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLoginAt { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<MovieList> MovieLists { get; set; }
        public virtual ICollection<MovieReport> MovieReports { get; set; }
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<SubtitleList> SubtitleLists { get; set; }
    }
}
