using System.Collections.Generic;

namespace Webshop.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : class //It's a type constraint on T, specifying that it must be a class.
    {
        TEntity Add(TEntity t );
        TEntity FindById(int? id);
        TEntity Modify(TEntity t);
        List<TEntity> GetAll();
        void Remove(TEntity t);
    }
}
