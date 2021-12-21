using System;
using System.Collections.Generic;

#nullable disable

namespace FilmaiOutAPI
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
