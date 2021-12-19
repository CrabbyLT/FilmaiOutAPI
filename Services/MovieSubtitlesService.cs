namespace FilmaiOutAPI.Services
{
    public class MovieSubtitlesService
    {
        private readonly RepositoryService _repository;
        public MovieSubtitlesService(RepositoryService repository)
        {
            _repository = repository;
        }
    }
}
