using System;

#nullable disable

namespace FilmaiOutAPI.Models.DatabaseModels
{
    public partial class CommentReport
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Reviewed { get; set; }
        public bool Accepted { get; set; }
        public int? FkCommentsId { get; set; }

        public virtual Comment FkComments { get; set; }
    }
}
