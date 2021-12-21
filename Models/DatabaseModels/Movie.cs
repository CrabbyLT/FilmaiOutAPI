using System;
using System.Collections.Generic;

#nullable disable

namespace FilmaiOutAPI.Models.DatabaseModels
{
    public partial class Movie
    {
        public Movie()
        {
            ListMovies = new HashSet<ListMovie>();
            MovieReports = new HashSet<MovieReport>();
            MovieReviews = new HashSet<MovieReview>();
            SubtitleLists = new HashSet<SubtitleList>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }

        public virtual ICollection<ListMovie> ListMovies { get; set; }
        public virtual ICollection<MovieReport> MovieReports { get; set; }
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
        public virtual ICollection<SubtitleList> SubtitleLists { get; set; }
    }
}
