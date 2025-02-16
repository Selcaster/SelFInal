using Musico.Core.Entities;
using Musico.Core.Repositories;
using Musico.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Musico.DAL.Repositories;

public class GenericRepository<T>(MusicoDbContext _context) : IGenericRepository<T> where T : BaseEntity, new()
{
    protected DbSet<T> Table => _context.Set<T>();

    public async Task<IEnumerable<T>> GetAllAsync(bool getAll = false, bool asNoTrack = true, params string[] includes)
    {
        IQueryable<T> query = Table;
        if (!getAll)
        {
            query = query.Where(x => x.IsDeleted == false);
        }
        return await _includeAndTracking(query, asNoTrack, includes).ToListAsync();
    }


    public async Task<T?> GetByIdAsync(int id, bool asNoTrack = true, params string[] includes)
    {
        return await _includeAndTracking(Table, asNoTrack, includes).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression, bool asNoTrack = true, params string[] includes)
    {

        return await _includeAndTracking(Table.Where(expression), asNoTrack, includes).ToListAsync();
    }

    public Task<bool> IsExistAsync(int id)
        => Table.AnyAsync(t => t.Id == id);
    public Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        => Table.AnyAsync(expression);

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task DeleteAndSaveAsync(int id)
    {
        await Table.Where(x => x.Id == id).ExecuteDeleteAsync();
    }

    public async Task<int> SaveAsync()
       => await _context.SaveChangesAsync();

    public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, bool asNoTrack = true, params string[] includes)
    {
        return await _includeAndTracking(Table.Where(expression), asNoTrack, includes).FirstOrDefaultAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id, false);
        Table.Remove(entity!);
    }
    public async Task<IEnumerable<T>> GetAllAsync(params string[] includes)
    {
        return await GetAllAsync(false, true, includes);
    }
    public async Task<T?> GetByIdAsync(int id, params string[] includes)
    {
        return await GetByIdAsync(id, true, includes);
    }

    public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
        return await GetWhereAsync(expression, true, includes);
    }

    public async Task<T?> GetFirstAsync(Expression<Func<T, bool>> expression, params string[] includes)
    {
        return await GetFirstAsync(expression, true, includes);
    }

    public async Task SoftDeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id, false);
        entity!.IsDeleted = true;
    }

    public void SoftDelete(T entity)
    {
        entity.IsDeleted = true;
    }


    public async Task ReverseSoftDeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id, false);
        entity!.IsDeleted = false;
    }

    public void ReverseSoftDelete(T entity)
    {
        entity.IsDeleted = false;
    }




    /// <summary>
    /// her methodda inlcude ve tracking yazmamaq uchun umumi priv method
    /// </summary>
    /// <param name="query">Bura query-ni yolla</param>
    /// <param name="asNoTrack">AsNoTrack olacagini yolla</param>
    /// <param name="includes">Include-lari yolla</param>
    /// <returns>Queyni qaytarir</returns>
    IQueryable<T> _includeAndTracking(IQueryable<T> query, bool asNoTrack, params string[] includes)
    {
        if (includes is not null && includes.Length > 0)
        {
            query = _chechkIncludes(query, includes);
            if (asNoTrack)
                query = query.AsNoTrackingWithIdentityResolution();
        }
        else
        {
            if (asNoTrack)
                query = query.AsNoTracking();
        }
        return query;
    }


    IQueryable<T> _chechkIncludes(IQueryable<T> query, params string[] includes)
    {
        foreach (var item in includes)
        {
            query = query.Include(item);
        }
        return query;
    }

    public async Task<IEnumerable<U>> GetAllAsync<U>(Expression<Func<T, U>> select)
    {
        return await Table.Select(select).ToListAsync();
    }
}