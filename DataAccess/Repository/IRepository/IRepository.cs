using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable <T> GetAll();
        T Get(Expression<Func<T,bool>> filter);
        bool Update(T entity);
        bool Remove(T entity);
        bool Add(T entity);
        bool RemoveRange(IEnumerable<T> entities);

        


    }
}
