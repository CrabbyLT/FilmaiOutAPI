namespace FilmaiOutAPI.Models.Auth
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Age { get; set; }
    }
}
