using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ProjectData
{
    public class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public User Creator { get; set; }

        public Post Post { get; set; }

    }
}
