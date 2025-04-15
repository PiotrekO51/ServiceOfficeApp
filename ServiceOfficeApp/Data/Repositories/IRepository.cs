
using ServiceOfficeApp.Data.Entities;

namespace ServiceOfficeApp.Data.Repositories;

public interface IRepository<T> : IWriteRepository<T> , IReadRepository<T> where T : class, IEntity, new()
{
    public event EventHandler<T>? ItemAdded;
    public event EventHandler<T>? ItemDeleted;
    public event EventHandler<T>? ItemUpdated;
}
