
using ServiceOfficeApp.Data.Entities;

namespace ServiceOfficeApp.Data.Repositories
{
    public interface IWriteRepository<in T> where T : class, IEntity
    {
        void Add(T item);
        void Remove(T item);
        void UppDateItem(int index, T item);
        void Save();
    }
}
