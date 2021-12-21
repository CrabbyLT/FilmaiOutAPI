using FilmaiOutAPI.Models;
using FilmaiOutAPI.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Services
{
    public class RepositoryService
    {
        private readonly FilmaiOutContext _context;
        public RepositoryService(FilmaiOutContext filmaiOutContext)
        {
            _context = filmaiOutContext;
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

        internal async Task<int> CreateMovieListAsync(MovieListModel movieListModel)
        {
            var subtitleList = await _context.MovieLists.AddAsync(new MovieList()
            {
                Text = movieListModel.Name,
                Description = movieListModel.Description,
                CreatedAt = DateTime.Now
                //FkUsers = movieListModel.UserName    //UNCOMMENT WHEN FKUSERS ARE HERE
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
            return _context.SubtitleLists.Take(10).Skip(0).ToList();
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
            return _context.MovieReviews.Take(10).Skip(0).ToList();
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
                Name = postModel.Name,
                Text = postModel.Text,
                CreatedAt = DateTime.Now,
            });
            await _context.SaveChangesAsync();

            return post.Entity.Id;
        }

        internal IEnumerable<Post> GetPosts()
        {
            return _context.Posts.Take(10).Skip(0).ToList();
        }

        internal async Task<int> UpdatePostAsync(PostUpdateModel postModel)
        {
            var post = GetPostById(postModel.PostId);
            if (post == null)
            {
                throw new ArgumentNullException(nameof(postModel));
            }

            post = UpdatePostFromPostUpdateModel(post, postModel);
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

        internal User CheckIfUserExists(LoginModel loginModel)
        {
            return _context.Users.FirstOrDefault(u => u.Email.Equals(loginModel.Email) && u.PasswordHash.Equals(loginModel.PasswordHash)); 
        }

        internal bool DeleteUser(string name)
        {
            var user = GetUserByName(name);
            var result = _context.Users.Remove(user);
            _context.SaveChangesAsync();

            return result != null;
        }
        private static Post UpdatePostFromPostUpdateModel(Post post, PostUpdateModel postModel)
        {
            return new Post()
            {
                Id = post.Id,
                Name = postModel.Name,
                Text = postModel.Text,
                Comments = post.Comments,
                Likes = post.Likes,
                Dislikes = post.Dislikes,
                CreatedAt = post.CreatedAt,
                LastEditedAt = DateTime.Now,
            };
        }
    }
}
