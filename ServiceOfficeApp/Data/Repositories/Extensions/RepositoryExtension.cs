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
    public static void ExportToJson<T>(this IRepository<T> repository, string filePath)
    where T : class, IEntity, new()
    {
        var items = repository.GetAll();
        var json = JsonSerializer.Serialize(items);
        File.WriteAllText(filePath, json);
    }
    public static void ImportFromJson<T>(this IRepository<T> repository, string filePath)
    where T : class, IEntity, new()
    {
        var json = File.ReadAllText(filePath);
        var items = JsonSerializer.Deserialize<IEnumerable<T>>(json);
        if (items != null)
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }

}

