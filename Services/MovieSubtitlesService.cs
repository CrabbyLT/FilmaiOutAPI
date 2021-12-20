using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Services
{
    public class MovieSubtitlesService
    {
        private readonly RepositoryService _repository;
        public MovieSubtitlesService(RepositoryService repository)
        {
            _repository = repository;
        }
        public IEnumerable<SubtitleList> GetSubtitles()
        {
            return _repository.GetSubList();
        }

        public async Task DeleteSubtitleList(int id)
        {
            await _repository.DeleteSubList(id);
        }
    }
}
