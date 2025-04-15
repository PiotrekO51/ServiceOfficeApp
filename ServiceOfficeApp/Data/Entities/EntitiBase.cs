
namespace ServiceOfficeApp.Data.Entities;
public class EntitiBase : IEntity
{
    public int? Id { get; set; }
    public string? Manufacturer { get; set; }
    public string? Company { get; set; }
    public string? ZipCode { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Phone { get; set; }
}
