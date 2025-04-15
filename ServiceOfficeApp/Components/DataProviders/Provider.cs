using ServiceAndWarrantyRecorder.Data;
using ServiceAndWarrantyRecorder.Data.Entities;
using ServiceOfficeApp.Data.Entities;
using ServiceOfficeApp.Data.Repositories;

namespace ServiceOfficeApp.Components.DataProviders;

public class Provider : IProvider
{
    private readonly IRepository<Installer> _repositoryInstaller;
    private readonly IRepository<DeviceList> _repositoryDeviceList;
    public Provider(IRepository<Installer> repositoryInstaller, IRepository<DeviceList> repositoryDeviceList)
    {
        _repositoryInstaller = repositoryInstaller;
        _repositoryDeviceList = repositoryDeviceList;
    }
    public Installer InstallerLauncher(int id)
    {
        var installer = _repositoryInstaller.GetAll();
        return installer.SingleOrDefault(c  => c.Id == id,
            new Installer { Id = 0, Name = $"nie znaleziono  Id: {id}" });
    }
    public  DeviceList Device (int id)
    {
        var device = _repositoryDeviceList.GetAll();
        return device.SingleOrDefault(c => c.Id == id,
            new DeviceList { Id = 0, DeviceName = $"nie znaleziono  Id: {id}" });
    }
}
