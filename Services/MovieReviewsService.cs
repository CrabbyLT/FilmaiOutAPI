using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Services
{
    public class MovieReviewsService
    {
        private readonly RepositoryService _repository;

        public MovieReviewsService(RepositoryService repository)
        {
            _repository = repository;
        }

        public IEnumerable<MovieReview> GetReviews()
        {
            return _repository.GetMovieReview();
        }

        public async Task DeleteMovieReview(int id)
        {
            await _repository.DeleteMovieReview(id);
        }
    }
}
