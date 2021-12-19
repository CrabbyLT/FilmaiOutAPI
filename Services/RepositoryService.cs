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

        internal bool CheckIfUserExists(LoginModel loginModel)
        {
            var result = _context.Users.FirstOrDefault(u => u.Email.Equals(loginModel.Email) && u.PasswordHash.Equals(loginModel.PasswordHash));

            return result != null;
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
