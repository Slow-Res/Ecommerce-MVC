using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;
using Models;

namespace DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        bool Update(Category obj);
       
    }
}
