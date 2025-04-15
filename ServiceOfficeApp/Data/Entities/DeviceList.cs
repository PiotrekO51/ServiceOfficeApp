
namespace ServiceOfficeApp.Data.Entities;

public class DeviceList: IEntity
{ 
    public string? Manufacturer { get; set; }
    public string DeviceName { get; set; }
    public string PowerFactor { get; set; }
    public int? Id { get; set; }
}
