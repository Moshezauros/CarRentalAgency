using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Entities
{
    public interface IUnitOfWork
    {
        void Create<T>(T entity) where T : class;
        IEnumerable<T> Get<T>() where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Save();
    }
}
