using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectData.Providers
{
    interface ICrudProvider<T>
    {
        T GetById(int id);

        void Update(T obj);

        void Update(int id, T obj);

        void Delete(int id);

        void Create(T obj);

        void GetAll();
    }
}
