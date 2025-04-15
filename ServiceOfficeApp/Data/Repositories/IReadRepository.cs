using ServiceOfficeApp.Data.Entities;
namespace ServiceOfficeApp.Data.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity, new()
    {
        IEnumerable<T> GetAll();

        int GetNumberId(string txt);

        T? GetById(int id);
    }
}
