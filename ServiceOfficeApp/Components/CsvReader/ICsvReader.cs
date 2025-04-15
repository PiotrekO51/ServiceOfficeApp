
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ServiceOfficeApp.Data.Entities;

namespace ServiceOfficeApp.Components.CsvReader;

public interface ICsvReader
{
    List<Installer> ReadFileInstaller(string filename);
    List<Designer> ReadFileDesigner(string filename);
    List<DeviceList> ReadFileDeviceList(string filename);
}
