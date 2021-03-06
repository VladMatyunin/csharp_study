﻿using ProjectData.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ProjectData
{
    public interface IUserProvider : ICrudProvider<User>
    {
        Task<User> FindByEmail(string email);
    }
}
