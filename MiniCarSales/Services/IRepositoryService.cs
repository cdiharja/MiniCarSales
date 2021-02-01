using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarSales.Services
{
    public interface IRepositoryService<T>
    {
        public T Create(T data);
        public IEnumerable<T> GetAll();
    }
}
