using FilmaiOutAPI.Models;
using FilmaiOutAPI.Models.DatabaseModels;
using System;
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

        internal async Task<int> CreateMovieList(MovieListModel movieListModel)
        {
            return await _repository.CreateMovieListAsync(movieListModel);
        }

        internal Movie GetMovie(string id)
        {
            return _repository.GetMovie(id);
        }

        internal async Task<int> UpdateMovieList(string name, string description, int id)
        {
            return await _repository.UpdateMovieListAsync(name,description,id);
        }

        internal Task AddMovieToMovieList(int movieListId, string movieImdbId)
        {
            return _repository.AddMovieToMovieList(movieListId, movieImdbId);
        }

        internal MovieList GetPersonalMovieList(int id)
        {
            return _repository.GetListMovie(id);
        }
    }
}
