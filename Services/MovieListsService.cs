using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Services
{
    public class MovieListsService
    {
        private readonly RepositoryService _repository;

        public MovieListsService(RepositoryService repository)
        {
            _repository = repository;
        }

        public IEnumerable<MovieList> GetMovieList()
        {
            return _repository.GetLikedMovieLists();
        }

        public async Task DeleteMovieList(int id)
        {
            await _repository.DeleteLikedMovieLists(id);
        }
    }
}
