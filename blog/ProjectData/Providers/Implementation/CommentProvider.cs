using ProjectData.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Providers
{
    class CommentProvider : ICommentProvider
    {
        private BlogDatabaseContext _dbContext;
        public CommentProvider(BlogDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Comment obj)
        {
            return _dbContext.Comments.AddAsync(obj);            
        }

        public Task Delete(int id)
        {
            return Task.Run(()=>_dbContext.Comments.Remove(GetById(id).Result));
        }

        public Task<IEnumerable<Comment>> GetAll()
        {
            return Task.Run(()=>(IEnumerable<Comment>)_dbContext.Set<Comment>());
        }

        public Task<Comment> GetById(int id)
        {
            return _dbContext.Comments.FindAsync(id);
        }

        public Task Update(Comment obj)
        {
            return Task.Run(()=> _dbContext.Update(obj));
        }

        public Task Update(int id, Comment obj)
        {
            return Update(GetById(id).Result);
        }
    }
}
