using FilmaiOutAPI.Models;
using FilmaiOutAPI.Models.Auth;
using FilmaiOutAPI.Models.DatabaseModels;
using IMDbApiLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Services
{
    public class RepositoryService
    {
        private readonly FilmaiOutContext _context;
        private readonly ApiLib _appLib;

        public RepositoryService(FilmaiOutContext filmaiOutContext)
        {
            _context = filmaiOutContext;
            _appLib = new ApiLib("k_wh57q0cw");
        }

        internal IEnumerable<Comment> GetPostCommentsById(int postId)
        {
            return _context.Comments.Where(p => p.FkPostsId == postId).ToList();
        }

        internal async Task<int> UpdateMovieListAsync(string name, string description, int id)
        {
            var movieList = _context.MovieLists.FirstOrDefault(p => p.Id.Equals(id));
            if (movieList != null)
            {
                movieList.Text = name;
                movieList.Description = description;
                _context.MovieLists.Update(movieList);
                await _context.SaveChangesAsync();
            }
            return movieList.Id;
        }

        internal Movie GetMovie(string id)
        {
            return _context.Movies.FirstOrDefault(movie => movie.Id.Equals(id));
        }

        internal async Task AddMovieToMovieList(int movieListId, string movieImdbId)
        {
            var movieList = GetMovieList(movieListId);
            if (_context.Movies.FirstOrDefault(movie => movie.Id == movieImdbId) == null)
            {
                var movie = await _appLib.TitleAsync(movieImdbId);
                var movieToDb = new Movie()
                {
                    Id = movie.Id,
                    CreatedAt = DateTime.Parse(movie.ReleaseDate),
                    Description = movie.Plot,
                    Duration = string.IsNullOrWhiteSpace(movie.RuntimeMins) ? 0 : Convert.ToInt32(movie.RuntimeMins),
                    Language = movie.Languages.Split(", ").First(),
                    Name = movie.FullTitle
                };
                await _context.Movies.AddAsync(movieToDb);
            }
            
            await _context.ListMovies.AddAsync(new ListMovie()
            {
                FkMovies = movieImdbId,
                FkMovieLists = movieList.Id
            });
            await _context.SaveChangesAsync();
        }

        internal MovieList GetListMovie(int id)
        {
            var movieList = _context.MovieLists.FirstOrDefault(list => list.Id.Equals(id));
            if (movieList != null)
            {
                var movies = _context.ListMovies.Where(list => list.FkMovieLists.Equals(id)).ToList();
                movieList.ListMovies = movies;
            }

            return movieList;
        }

        internal async Task<int> CreateMovieListAsync(MovieListModel movieListModel)
        {
            var subtitleList = await _context.MovieLists.AddAsync(new MovieList()
            {
                Text = movieListModel.Name,
                Description = movieListModel.Description,
                CreatedAt = DateTime.Now,
                FkUsersName = movieListModel.UserName
            });
            await _context.SaveChangesAsync();

            return subtitleList.Entity.Id;
        }

        internal async Task<int> CreateSubtitleListAsync(SubtitleListModel subtitleListModel)
        {
            var subtitleList = await _context.SubtitleLists.AddAsync(new SubtitleList()
            {
                Language = subtitleListModel.Language,
                FkUsers = subtitleListModel.UserName,
                FkMovies = subtitleListModel.MovieId,
            });
            await _context.SaveChangesAsync();

            return subtitleList.Entity.Id;
        }

        internal async Task<int> UpdateSubtitleListAsync(string language, int id)
        {
            var subtitleList = _context.SubtitleLists.FirstOrDefault(p => p.Id.Equals(id));
            if (subtitleList != null)
            {
                subtitleList.Language = language;
                _context.SubtitleLists.Update(subtitleList);
                await _context.SaveChangesAsync();
            }
            return subtitleList.Id;
        }

        internal IEnumerable<SubtitleList> GetSubList()
        {
            return _context.SubtitleLists.Take(10).Skip(0).OrderByDescending(list => list.FkUsers).ToList();
        }
        internal async Task DeleteSubList(int id)
        {
            var subtitle = _context.SubtitleLists.FirstOrDefault(p => p.Id.Equals(id));
            if (subtitle != null)
            {
                _context.SubtitleLists.Remove(subtitle);
                await _context.SaveChangesAsync();
            }
        }

        internal IEnumerable<MovieReview> GetMovieReview()
        {
            return _context.MovieReviews.Take(10).Skip(0).OrderByDescending(list => list.Text).ToList();
        }

        internal MovieList GetMovieList(int id)
        {
            return _context.MovieLists.FirstOrDefault(list => list.Id.Equals(id));
        }

        internal async Task<int> CreateMovieReviewAsync(MovieReviewModel movieReviewModel)
        {
            var movieReview = await _context.MovieReviews.AddAsync(new MovieReview()
            {
                Text = movieReviewModel.Text,
                CreatedAt = DateTime.Now,
                LastEditedAt = DateTime.Now,
                Score = movieReviewModel.Score,
                FkUsers = movieReviewModel.FkUsers,
                FkMovies = movieReviewModel.FkMovies
            }); 
            await _context.SaveChangesAsync();

            return movieReview.Entity.Id;
        }

        internal async Task<int> UpdateMovieReviewAsync(MovieReviewModel movieReviewModel, int id)
        {
            var review = _context.MovieReviews.FirstOrDefault(p => p.Id.Equals(id));
            if (review == null)
            {
                throw new ArgumentNullException(nameof(movieReviewModel));
            }

            review.Text = movieReviewModel.Text;
            review.Score = movieReviewModel.Score;

            _context.MovieReviews.Update(review);
            await _context.SaveChangesAsync();
            return review.Id;
        }

        internal async Task DeleteMovieReview(int id)
        {
            var review = _context.MovieReviews.FirstOrDefault(p => p.Id.Equals(id));
            if (review != null)
            {
                _context.MovieReviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
        internal IEnumerable<MovieList> GetLikedMovieLists()
        {
            return _context.MovieLists.Take(10).Skip(0).ToList();
        }
        internal async Task DeleteLikedMovieLists(int id)
        {
            var list = _context.MovieLists.FirstOrDefault(p => p.Id.Equals(id));
            if (list != null)
            {
                _context.MovieLists.Remove(list);
                await _context.SaveChangesAsync();
            }
        }

        internal Post GetPostById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id.Equals(id));
        }

        internal async Task<int> CreatePostAsync(PostModel postModel)
        {
            var post = await _context.Posts.AddAsync(new Post()
            {
                FkUsersName=postModel.UserName,
                Name = postModel.Name,
                Text = postModel.Text,
                CreatedAt = DateTime.Now,
            });
            await _context.SaveChangesAsync();

            return post.Entity.Id;
        }

        internal IEnumerable<Post> GetPosts()
        {
            return _context.Posts.Take(10).Skip(0).OrderByDescending(post => post.Name).ToList();
        }

        internal async Task<int> UpdatePostAsync(PostUpdateModel postModel)
        {
            var post = GetPostById(postModel.PostId);
            if (post == null)
            {
                throw new ArgumentNullException(nameof(postModel));
            }

            //post = UpdatePostFromPostUpdateModel(post, postModel);
            post.Text = postModel.Text;
            post.Name = postModel.Title;
            post.LastEditedAt = DateTime.Now;
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            return post.Id;
        }

        internal Comment GetPostCommentById(int commentId)
        {
            return _context.Comments.FirstOrDefault(comment => comment.Id.Equals(commentId));
        }

        internal async Task<int> CreatePostCommentAsync(Post post, CommentCreateModel commentModel)
        {
            var comment = new Comment()
            {
                CreatedAt = DateTime.Now,
                FkPostsId = post.Id,
                FkUsersName = commentModel.Name,
                Text = commentModel.Text,
                LastEditedAt = DateTime.Now
            };
            foreach(var swearword in GetSwearWords())
            {
                if (comment.Text.Contains(swearword))
                {
                    comment.Text = "Šis komentaras buvo pašalintas dėl necenzūrinių žodžių";
                    break;
                }
            }
            var commentEntity = await _context.Comments.AddAsync(comment);
            post.Comments.Add(comment);
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            return commentEntity.Entity.Id;
        }

        internal async Task DeletePostCommentAsync(Post post, Comment comment)
        {
            post.Comments.Remove(comment);
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        internal async Task DeletePostAsync(int id)
        {
            var post = GetPostById(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public User GetUserByName(string name)
        {
            return _context.Users.FirstOrDefault(u => u.Name == name);
        }

        public async Task InsertUserAsync(RegisterModel user)
        {
            
            await _context.Users.AddAsync(new User()
            {
                Administrator = false,
                Age = (short)user.Age,
                CreatedAt = DateTime.Now,
                Email = user.Email,
                Name = user.Name,
                PasswordHash = user.PasswordHash
            }); 
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(UserUpdateModel user)
        {
            var userDB = GetUserByName(user.Name);
            userDB.Age = user.Age;
            userDB.Email = user.Email;
            _context.Users.Update(userDB);
            await _context.SaveChangesAsync();
        }

        internal User CheckIfUserExists(LoginModel loginModel)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Equals(loginModel.Email) && u.PasswordHash.Equals(loginModel.PasswordHash)); 
        }

        internal async Task<bool> DeleteUserAsync(string name)
        {
            var user = GetUserByName(name);
            var result = _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            _ = GetUserByName(name);

            return result != null;
        }

        private static List<string> GetSwearWords()
        {
            var swearWordsList = new List<string>();
            swearWordsList.Add("fuck");
            swearWordsList.Add("blet");
            swearWordsList.Add("lopas");
            swearWordsList.Add("pydaras");
            swearWordsList.Add("dūxas");
            return swearWordsList;
        }

        //private static Post UpdatePostFromPostUpdateModel(Post post, PostUpdateModel postModel)
        //{
        //    return new Post()
        //    {
        //        Id = post.Id,
        //        Name = postModel.Name,
        //        Text = postModel.Text,
        //        Comments = post.Comments,
        //        Likes = post.Likes,
        //        Dislikes = post.Dislikes,
        //        CreatedAt = post.CreatedAt,
        //        LastEditedAt = DateTime.Now,
        //    };
        //}
    }
}
