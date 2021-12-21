using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Models
{
    public class MovieReviewModel
    {
        public string Text { get; set; }
        public decimal Score { get; set; }
        public string FkUsers { get; set; }
        public int? FkMovies { get; set; }

    }
}
