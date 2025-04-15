
using ServiceOfficeApp.Data.Entities;

namespace ServiceAndWarrantyRecorder.Data.Entities;

public class Device : EntitiBase
{
    public string Manufacturer { get; set; }
    public string DeviceName { get; set; }
    public string SerialNumber { get; set; }
    public string CompanyLunching { get; set; }
    public DateTime LunchData { get; set; }

}
