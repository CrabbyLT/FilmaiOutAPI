#nullable disable

namespace FilmaiOutAPI
{
    public partial class SubtitleList
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string FkUsers { get; set; }
        public int? FkMovies { get; set; }

        public virtual Movie FkMoviesNavigation { get; set; }
        public virtual User FkUsersNavigation { get; set; }
    }
}
