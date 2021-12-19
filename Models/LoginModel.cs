using System;

namespace FilmaiOutAPI.Models.Auth
{
    public class LoginModel : IEquatable<LoginModel>
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public bool Equals(LoginModel other)
        {
            if (other == null) return false;
            if (Email.Equals(other.Email)) return false;
            if (Email.Equals(other.Email))
            {
                if (!PasswordHash.Equals(other.PasswordHash)) return false;
            }

            return true;
        }
    }
}
