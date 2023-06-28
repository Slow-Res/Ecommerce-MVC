using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;
using DataAcess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public bool Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
         

        }

        public T  Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            try
            {
                IQueryable<T> set = dbSet;
                set = set.Where(filter);
                return set.FirstOrDefault<T>();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;    
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                IQueryable<T> set = dbSet;
                return set.ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<T>();
            }
            
        }

        public bool Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                dbSet.RemoveRange(entities);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
} 
