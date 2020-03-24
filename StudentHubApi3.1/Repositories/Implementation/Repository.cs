using StudentHubApi1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentHubApi1.Repositories.Implementation
{
    public class Repository<T>:IRepository<T> where T:class
    {
        private readonly DbContext dbContext;
        public Repository(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public void AddEntity(T Entity)
        {
            dbContext.Add(Entity);
           dbContext.SaveChanges();
        }

        public void DeleteEntity(Guid id)
        {
            var entity = dbContext.Set<T>().Find(id);
            dbContext.Remove(entity);
           dbContext.SaveChanges();
        }

        public void EditEntity(Guid id, T entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<T> FindWhere(Func<T, bool> Predicate)
        {
            return dbContext.Set<T>().Where(Predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetWithId(Guid Id)
        {
            return dbContext.Set<T>().Find(Id);
        }
    }
}
