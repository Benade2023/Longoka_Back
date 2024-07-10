using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Domain.Interfaces
{
    public interface IProvider<T, K> where T : class
    {
        void Create(T entity);
        List<T> GetAll();
        T GetById(K id);
        void Update(T entity);
        void Delete(K id);
    }
}
