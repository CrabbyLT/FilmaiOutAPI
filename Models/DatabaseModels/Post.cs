using System;
using System.Collections.Generic;

#nullable disable

namespace FilmaiOutAPI
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Views { get; set; }
        public DateTime LastEditedAt { get; set; }
        public string FkUsersName { get; set; }

        public virtual User FkUsersNameNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
