﻿using System;
using System.Collections.Generic;

#nullable disable

namespace FilmaiOutAPI
{
    public partial class MovieList
    {
        public MovieList()
        {
            ListMovies = new HashSet<ListMovie>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public string FkUsersName { get; set; }

        public virtual User FkUsersNameNavigation { get; set; }
        public virtual ICollection<ListMovie> ListMovies { get; set; }
    }
}
