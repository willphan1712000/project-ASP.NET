using System.Linq.Expressions;
using ASP.NET_Web.Repo;
using Microsoft.EntityFrameworkCore;

namespace APS.NET_Web.Repo;

public class Repo<TEntity>(DbContext context) : IRepo<TEntity> where TEntity : class
{
    protected readonly DbContext Context = context;

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate);
    }

    public TEntity? Get(int id)
    {
        return Context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return [.. Context.Set<TEntity>()];
    }
    public void Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public void Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
    }
}