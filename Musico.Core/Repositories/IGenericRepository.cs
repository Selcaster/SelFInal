using Musico.Core.Entities;
using System.Linq.Expressions;

namespace Musico.Core.Repositories;

public interface IGenericRepository<T> where T : BaseEntity, new()
{
    Task<IEnumerable<T>> GetAllAsync(bool getAll = false, bool asNoTrack = true, params string[] includes);
    Task<IEnumerable<U>> GetAllAsync<U>(Expression<Func<T, U>> select);
    Task<IEnumerable<T>> GetAllAsync(params string[] includes);
    Task<T?> GetByIdAsync(int id, bool asNoTrack = true, params string[] includes);
    Task<T?> GetByIdAsync(int id, params string[] includes);
    Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression, bool asNoTrack = true, params string[] includes);
    Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression, params string[] includes);
    Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, bool asNoTrack = true, params string[] includes);
    Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, params string[] includes);
    Task<bool> IsExistAsync(int id);
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
    Task AddAsync(T entity);
    void Delete(T entity);
    Task DeleteAsync(int id);
    Task SoftDeleteAsync(int id);
    void SoftDelete(T entity);
    Task ReverseSoftDeleteAsync(int id);
    void ReverseSoftDelete(T entity);
    Task DeleteAndSaveAsync(int id);
    Task<int> SaveAsync();
}