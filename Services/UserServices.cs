using FilmaiOutAPI.Models;
using FilmaiOutAPI.Models.Auth;
using FilmaiOutAPI.Models.DatabaseModels;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Services
{
    public class UserServices
    {
        private readonly RepositoryService _repositoryService;

        public UserServices(RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public async Task<bool> RegisterAsync(RegisterModel registerModel)
        {
            if (registerModel == null)
            {
                return false;
            }

            await _repositoryService.InsertUserAsync(registerModel);

            return true;
        }

        public async Task<bool> UpdateAsync(UserUpdateModel userModel)
        {
            if (userModel == null)
            {
                return false;
            }

            await _repositoryService.UpdateUserAsync(userModel);

            return true;
        }

        public User LogUserIn(LoginModel loginModel)
        {
            return _repositoryService.CheckIfUserExists(loginModel);
        }

        public Task<bool> DeleteUserAsync(string name)
        {
            return _repositoryService.DeleteUserAsync(name);
        }
    }
}
