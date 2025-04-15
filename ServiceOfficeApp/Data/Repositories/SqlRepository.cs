

using Microsoft.EntityFrameworkCore;
using ServiceOfficeApp.Data.Entities;

namespace ServiceOfficeApp.Data.Repositories;

public class SqlRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly ServiceOfficeDbContext _dbContext;
    private readonly DbSet<T> _dbSet;
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemDeleted;
    public event EventHandler<T>? ItemUpdated;



    public SqlRepository(ServiceOfficeDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(T item)
    {
        _dbSet.Add(item);
        ItemAdded?.Invoke(this, item);
    }

    public T? GetById(int id) => _dbSet.Single(c  => c.Id == id);

    public int GetNumberId(string txt)
    {
        int idCount = _dbSet.Count();
        Console.WriteLine($"Długość listy {txt} = {idCount}");
        return idCount;
    }

    public void UppDateItem(int index, T item)
    {
        _dbContext.Update(item);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
        ItemDeleted?.Invoke(this, item);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}
