using FilmaiOutAPI.Models;
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

        internal async Task<int> CreateReviewAsync(MovieReviewModel subtitleListModel)
        {
            return await _repository.CreateMovieReviewAsync(subtitleListModel);
        }

        internal async Task<int> UpdateReviewAsync(MovieReviewModel subtitleListModel, int id)
        {
            return await _repository.UpdateMovieReviewAsync(subtitleListModel, id);
        }

        public async Task DeleteMovieReview(int id)
        {
            await _repository.DeleteMovieReview(id);
        }
    }
}
