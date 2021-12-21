#nullable disable

namespace FilmaiOutAPI.Models.DatabaseModels
{
    public partial class Subtitle
    {
        public int StartAt { get; set; }
        public string Text { get; set; }
        public int FinishAt { get; set; }
        public int? FkSubtitleLists { get; set; }

        public virtual SubtitleList FkSubtitleListsNavigation { get; set; }
    }
}
