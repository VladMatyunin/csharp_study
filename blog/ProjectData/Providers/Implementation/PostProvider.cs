using ProjectData.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Providers
{
    class PostProvider : IPostProvider
    {
        private BlogDatabaseContext _dbContext;

        public PostProvider(BlogDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Post obj)
        {
            return _dbContext.Posts.AddAsync(obj);
        }

        public Task Delete(int id)
        {
            return Task.Run(() => _dbContext.Posts.Remove(GetById(id).Result));
        }

        public Task<IEnumerable<Post>> GetAll()
        {
            return Task.Run(() => (IEnumerable<Post>)_dbContext.Set<Post>());
        }

        public Task<Post> GetById(int id)
        {
            return _dbContext.Posts.FindAsync(id);
        }

        public Task Update(Post obj)
        {
            return Task.Run(()=>_dbContext.Posts.Update(obj));
        }

        public Task Update(int id, Post obj)
        {
            return Task.Run(() => Update(GetById(id).Result));
        }
    }
}
