using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectData.Model
{
    public class Post
    {
        public Post()
        {
            Comments = new List<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public User Author { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
