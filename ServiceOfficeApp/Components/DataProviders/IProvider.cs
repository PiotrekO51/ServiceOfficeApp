using ServiceOfficeApp.Data.Entities;

namespace ServiceOfficeApp.Components.DataProviders
{
    public interface IProvider
   
    {
        Installer InstallerLauncher(int id);
        DeviceList Device(int id);
    }
}
