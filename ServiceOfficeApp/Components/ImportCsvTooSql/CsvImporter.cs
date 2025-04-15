
using ServiceOfficeApp.Components.CsvReader;
using ServiceOfficeApp.Data;
using ServiceOfficeApp.Data.Entities;
using ServiceOfficeApp.Data.Repositories;
namespace ServiceOfficeApp.Components.ImportCsvTooSql;

public class CsvImporter:ICsvImporter
{
    private readonly IRepository<Installer> _repositoryInstaller;
    private readonly IRepository<Designer> _repositoryDesigner;
    private readonly IRepository<DeviceList> _repositoryDeviceList;
    private readonly ServiceOfficeDbContext _context;
    private readonly ICsvReader _csvReader;

    public CsvImporter(IRepository<Installer> repositoryInstaller, IRepository<Designer> repositoryDesigner,
        IRepository<DeviceList> repositoryDeviceList, ICsvReader csvReader, ServiceOfficeDbContext context)
    {
        _context = context;
        _repositoryInstaller = repositoryInstaller;
        _repositoryDesigner = repositoryDesigner;
        _repositoryDeviceList = repositoryDeviceList;
        _csvReader = csvReader;
    }

    public void InstallerAdderTooSql()
    {
        var baseInstaller = _context.Installers.Count();
        if (baseInstaller == 0)
        {
            Console.WriteLine("Dodajemy Instalatorów do bazy do SQL");
            var installer = _csvReader.ReadFileInstaller("Resources\\Files\\Instalers.csv");
            foreach (var item in installer)
            {
                _repositoryInstaller.Add(new ()
                {
                    Company = item.Company,
                    ZipCode = item.ZipCode,
                    City = item.City,
                    Street = item.Street,
                    Name = item.Name,
                    Surname = item.Surname,
                    Phone = item.Phone,
                    Authorization = item.Authorization,
                    Date = item.Date
                });
            }
            _repositoryInstaller.Save();
        }
        else { Console.WriteLine("Baza Instalatorów istnieje"); Thread.Sleep(500); }
    }
    public void DesignerAdderTooSql()
    {
        var baseInstaller = _repositoryDesigner.GetAll().Count();
        if (baseInstaller == 0)
        {
            Console.WriteLine("Dodajemy Projektantów do bazy do SQL");
            var designer = _csvReader.ReadFileDesigner("Resources\\Files\\Designers.csv");
            foreach (var item in designer)
            {
                _repositoryDesigner.Add(new ()
                {
                    Company = item.Company,
                    ZipCode = item.ZipCode,
                    City = item.City,
                    Street = item.Street,
                    Name = item.Name,
                    Surname = item.Surname,
                    Phone = item.Phone,
                });
            }
            _repositoryDesigner.Save();
        }
        else { Console.WriteLine("Baza Projektantów istnieje"); Thread.Sleep(500); }
    }

    public void DeviceListAdderTooSql()
    {
        var baseInstaller = _repositoryDeviceList.GetAll().Count();
        if (baseInstaller == 0)
        {
            Console.WriteLine("Dodajemy urządzenia do bazy SQL");
            var designer = _csvReader.ReadFileDeviceList("Resources\\Files\\device.csv");
            foreach (var item in designer)
            {
                _repositoryDeviceList.Add(new ()
                {
                    Manufacturer = item.Manufacturer,
                    DeviceName = item.DeviceName,
                    PowerFactor = item.PowerFactor,
                });
            }
            _repositoryDeviceList.Save();
        }
        else { Console.WriteLine("Baza Urzadzeń istnieje"); Thread.Sleep(500); }
    }
}
