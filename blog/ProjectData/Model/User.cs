using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ProjectData
{
    public class User
    {
        public User()
        {
            PostsCreated = new List<Post>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Post> PostsCreated { get; set; }
    }
}
