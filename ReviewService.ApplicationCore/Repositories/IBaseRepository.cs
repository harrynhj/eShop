using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewService.ApplicationCore.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Insert(T entity);
        Task<T> DeleteById(int id);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
