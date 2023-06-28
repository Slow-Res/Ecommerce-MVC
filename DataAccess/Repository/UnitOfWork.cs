using DataAccess.Repository.IRepository;
using DataAcess.Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
