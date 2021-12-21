using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Models
{
    public class UserUpdateModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public short Age { get; set; }
    }
}
