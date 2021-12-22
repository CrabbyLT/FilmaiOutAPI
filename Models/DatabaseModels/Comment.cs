using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace FilmaiOutAPI.Models.DatabaseModels
{
    public partial class Comment
    {
        public Comment()
        {
            CommentReports = new HashSet<CommentReport>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool Disabled { get; set; }
        public DateTime LastEditedAt { get; set; }
        public int? FkPostsId { get; set; }
        public string FkUsersName { get; set; }

        public virtual Post FkPosts { get; set; }

        [JsonIgnore]
        public virtual User FkUsersNameNavigation { get; set; }
        public virtual ICollection<CommentReport> CommentReports { get; set; }
    }
}
