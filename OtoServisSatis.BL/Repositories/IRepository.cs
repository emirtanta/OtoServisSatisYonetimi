using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OtoServisSatis.BL.Repositories
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T,bool>> expression);

        T Find(int id);
        T Get(Expression<Func<T, bool>> expression);

        IQueryable<T> GetAllByInclude(string table);

        int Add(T entity);
        int Update(T entity);
        int Delete(int id);
    }
}
