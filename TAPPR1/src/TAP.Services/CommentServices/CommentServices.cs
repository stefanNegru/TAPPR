using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TAP.Core.Entities;
using TAP.DataAccess.Repositories;
namespace TAP.Services.CommentServices
{
    public class CommentServices: ICommentServices
    {
        private readonly IDataRepository dataRepository;

        public CommentServices(IDataRepository dataRepository)
        {
            this.dataRepository = dataRepository;
        }
        public void CreateComment(Comment comment)
        {
            dataRepository.Insert(comment);
        }

        public void DeleteComment(Comment comment)
        {
            dataRepository.Delete(comment);
        }

        public void EditComment(Comment comment)
        {
            dataRepository.Update(comment);
        }

        public void DeleteComment(Guid commentId)
        {
            var result = dataRepository.Query<Comment>().FirstOrDefault(_ => _.Id == commentId);
            dataRepository.Delete(result);
        }

        public Task<IEnumerable<Comment>> GetBlogCommentsAsync(Guid blogid)
        {
            var results = dataRepository.Query<Comment>().Where(_ => _.BlogId == blogid).ToArray() as IEnumerable<Comment>;
            return Task.FromResult(results);
        }

        public Task<Comment> GetCommentAsync(Guid id)
        {
            var result = dataRepository.Query<Comment>().FirstOrDefault(_ => _.Id == id);
            return Task.FromResult(result);
        }
    }
}
