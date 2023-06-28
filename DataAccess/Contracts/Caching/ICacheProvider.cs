using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts.Caching
{
    public interface ICacheProvider
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan expirationTime);
        void Remove(string key);
    }
}
