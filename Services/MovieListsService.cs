namespace FilmaiOutAPI.Services
{
    public class MovieListsService
    {
        private readonly RepositoryService _repository;

        public MovieListsService(RepositoryService repository)
        {
            _repository = repository;
        }
    }
}
