using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Providers
{
    public interface ICrudProvider<T>
    {
        Task<T> GetById(int id);

        Task Update(T obj);

        Task Update(int id, T obj);

        Task Delete(int id);

        Task Create(T obj);

        Task<IEnumerable<T>> GetAll();
    }
}
