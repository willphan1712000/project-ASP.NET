using System.Linq.Expressions;

namespace ASP.NET_Web.Repo;

public interface IRepo<TEntity> where TEntity : class
{
    TEntity? Get(int id);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    void Add(TEntity entity);

    void Remove(TEntity entity);
}