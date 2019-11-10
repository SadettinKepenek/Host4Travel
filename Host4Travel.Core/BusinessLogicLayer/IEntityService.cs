using System.Collections.Generic;

namespace Host4Travel.Core.BusinessLogicLayer
{
    public interface IEntityService<T>
    {

        T GetById(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}