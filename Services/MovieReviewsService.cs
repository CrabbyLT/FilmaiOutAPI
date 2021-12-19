namespace FilmaiOutAPI.Services
{
    public class MovieReviewsService
    {
        private readonly RepositoryService _repository;

        public MovieReviewsService(RepositoryService repository)
        {
            _repository = repository;
        }
    }
}
