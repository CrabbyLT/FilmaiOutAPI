using FilmaiOutAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmaiOutAPI.Services
{
    public class PostsService
    {
        private readonly RepositoryService _repository;
        public PostsService(RepositoryService repository)
        {
            _repository = repository;
        }

        internal Comment GetComment(int id)
        {
            return _repository.GetPostCommentById(id);
        }

        internal IEnumerable<Comment> GetComments(int id)
        {
            return _repository.GetPostCommentsById(id);
        }
        internal Post GetPost(int id)
        {
            return _repository.GetPostById(id);
        }

        internal async Task<int> CreatePostAsync(PostModel postModel)
        {
            return await _repository.CreatePostAsync(postModel);
        }

        internal IEnumerable<Post> GetPosts()
        {
            return _repository.GetPosts();
        }

        internal async Task DeletePostAsync(int id)
        {
            await _repository.DeletePostAsync(id);
        }

        internal async Task<int> UpdatePost(PostUpdateModel postModel)
        {
            return await _repository.UpdatePostAsync(postModel);
        }

        internal async Task CreatePostCommentAsync(int id, CommentCreateModel commentModel)
        {
            var post = _repository.GetPostById(id);
            await _repository.CreatePostCommentAsync(post, commentModel);
        }

        internal async Task DeletePostCommentAsync(int postId, int commentId)
        {
            var post = _repository.GetPostById(postId);
            var comment = _repository.GetPostCommentById(commentId);
            await _repository.DeletePostCommentAsync(post, comment);
        }
    }
}
