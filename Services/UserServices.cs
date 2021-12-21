using FilmaiOutAPI.Models.Auth;
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

        public User LogUserIn(LoginModel loginModel)
        {
            return _repositoryService.CheckIfUserExists(loginModel);
        }

        public bool DeleteUserAsync(string name)
        {
            return _repositoryService.DeleteUser(name);
        }
    }
}
