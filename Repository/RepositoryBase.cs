using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly RepositoryContext repositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        this.repositoryContext = repositoryContext ;
    }

    public virtual void Create(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual void Delete(T entitiy)
    {
        throw new NotImplementedException();
    }
    public void Update(T entitiy)
    {
        throw new NotImplementedException();
    }

    public virtual IQueryable<T> FindAll(bool tracking) =>
                                !tracking ?
                                repositoryContext.Set<T>().AsNoTracking() :
                                repositoryContext.Set<T>();

    public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool tracking) =>
                                                !tracking ?
                                                repositoryContext.Set<T>()
                                                    .Where(expression).AsNoTracking() :
                                                repositoryContext.Set<T>()
                                                    .Where(expression);


}
