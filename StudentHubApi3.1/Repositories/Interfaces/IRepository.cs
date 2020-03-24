using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Repositories.Interfaces
{
     public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();

        T GetWithId(Guid Id);

         void AddEntity(T Entity);

        void EditEntity(Guid id, T entity);

        void DeleteEntity(Guid id);

        IEnumerable<T> FindWhere(Func<T, bool> Predicate);
    }
}
