using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ProjectData
{
    public class UserProvider : IUserProvider
    {
        private BlogDatabaseContext _dbContext;

        public UserProvider(BlogDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task Create(User obj)
        {
            return _dbContext.Users.AddAsync(obj);
        }

        public Task Delete(int id)
        {
            return Task.Run(()=>_dbContext.Remove(GetById(id).Result));
        }

        public async Task<User> FindByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return Task.Run(()=>(IEnumerable<User>)_dbContext.Set<User>());
        }

        public Task<User> GetById(int id)
        {
            return _dbContext.Users.FindAsync(id);
        }

        public Task Update(User obj)
        {
            return Task.Run(()=>_dbContext.Users.Update(obj));
        }

        public Task Update(int id, User obj)
        {
            return Task.Run(() => Update(GetById(id).Result));
        }
    }
}
