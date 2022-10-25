using System.Linq.Expressions;

namespace Clientes.Domain;

public interface IBaseRepository<T> : IDisposable where T : class
{
    Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
    Task<T> GetById(Guid id);
    Task<bool> Create(T model);
    Task<T> Update(Guid Id,T model);
    Task<bool> Delete(Guid id);
    Task<IEnumerable<T>> GetAll();
}