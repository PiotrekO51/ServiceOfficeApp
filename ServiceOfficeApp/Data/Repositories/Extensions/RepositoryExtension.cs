using ServiceOfficeApp.Data.Entities;
using System.Text.Json;

namespace ServiceOfficeApp.Data.Repositories.Extensions;

public static class RepositoryExtension
{
    public static void AddBatch<T>(this IRepository<T> repository, T[] items)
   where T : class, IEntity, new()
    {
        foreach (var emp in items)
        {
            repository.Add(emp);
        }
        repository.Save();
    }
    
}

