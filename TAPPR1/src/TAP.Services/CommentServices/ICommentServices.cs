using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TAP.Core.Entities;

namespace TAP.Services.CommentServices
{
    public interface ICommentServices
    {
        void CreateComment(Comment comment);

        void DeleteComment(Comment comment);

        void DeleteComment(Guid commentId);

        void EditComment(Comment comment);

        Task<IEnumerable<Comment>> GetBlogCommentsAsync(Guid userid);

        Task<Comment> GetCommentAsync(Guid Id);
    }
}
