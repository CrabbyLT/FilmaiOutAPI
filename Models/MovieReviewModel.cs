namespace FilmaiOutAPI.Models
{
    public class MovieReviewModel
    {
        public string Text { get; set; }
        public decimal Score { get; set; }
        public string FkUsers { get; set; }
        public string FkMovies { get; set; }

    }
}
