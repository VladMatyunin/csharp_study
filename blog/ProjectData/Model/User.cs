using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectData.Model
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

        private string Password { get; set; }

        private string Email { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Post> PostsCreated { get; set; }
    }
}
