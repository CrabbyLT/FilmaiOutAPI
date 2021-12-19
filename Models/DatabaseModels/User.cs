using System;
using System.Collections.Generic;

#nullable disable

namespace FilmaiOutAPI
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            MovieReports = new HashSet<MovieReport>();
            MovieReviews = new HashSet<MovieReview>();
            SubtitleLists = new HashSet<SubtitleList>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public short Age { get; set; }
        public bool Administrator { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLoginAt { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<MovieReport> MovieReports { get; set; }
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
        public virtual ICollection<SubtitleList> SubtitleLists { get; set; }
    }
}
