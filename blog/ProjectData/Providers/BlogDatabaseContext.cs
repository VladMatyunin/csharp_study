﻿using Microsoft.EntityFrameworkCore;
using ProjectData.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectData.Providers
{
    public class BlogDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }


    }
}
