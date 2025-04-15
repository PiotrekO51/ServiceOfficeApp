using Microsoft.EntityFrameworkCore;
using ServiceAndWarrantyRecorder.Data.Entities;
using ServiceOfficeApp.Data;
using ServiceOfficeApp.Data.Entities;
using ServiceOfficeApp.Data.Repositories;
using ServiceOfficeApp.Components.ReadingObjectData;
using ServiceOfficeApp.Components.DataProviders;
namespace ServiceOfficeApp.Components.AddingToObjects;

public class NewEntries : INewEntries
{
    private readonly IRepository<DeviceList> _repositoryDeviceList;
    private readonly IRepository<Installer> _repositoryInstaller;
    private readonly IRepository<Designer> _repositoryDesigner;
    private readonly IRepository<Device> _repositoryDevice;
    private readonly IObjectsReader _objectsReader;
    private readonly IProvider _provider;

    public NewEntries(IRepository<Installer> repositoryInstaller, IRepository<Designer> repositoryDesigner,
        IRepository<DeviceList> repositoryDeviceList, IRepository<Device> repositoryDevice, IProvider provider)

    {
        _provider = provider;
        _repositoryDevice = repositoryDevice;
        _repositoryDesigner = repositoryDesigner;
        _repositoryInstaller = repositoryInstaller;
        _repositoryDeviceList = repositoryDeviceList;
        _repositoryInstaller.ItemAdded += InfoInstallerAdded;

    }

    void InfoInstallerAdded(object? sender, Installer e)
    {
        WriteDataToFile("InstallerBackUp.txt", $"Dodano instalatora {e.Company} from {sender?.GetType().Name}");
    }

    public void WriteDataToFile(string filetxt, string txt)
    {
        using (var writer = File.AppendText(filetxt))
        {
            writer.WriteLine($"{DateTime.Now} : {txt}");
        }
    }

    public void InatallerAdding()
    {
        _repositoryInstaller.Add(new Installer()
        {
            Company = DataInputs("nazwę firmy"),
            ZipCode = DataInputs("kod pocztowy"),
            City = DataInputs("nazwę miasta"),
            Street = DataInputs("ulicę i numer"),
            Name = DataInputs("Imię"),
            Surname = DataInputs("Nazwisko"),
            Phone = DataInputs("numer telefonu"),
            Authorization = AutorisationCode("sześcio cyfrowy kod autoryzacyjny"),
            Date = InputDateTime("datę")
        });
        _repositoryInstaller.Save();
    }
    public void DesignerAdding()
    {
        _repositoryDesigner.Add(new Designer()
        {
            Company = DataInputs("nazwę firmy"),
            ZipCode = DataInputs("kod pocztowy"),
            City = DataInputs("nazwę miasta"),
            Street = DataInputs("ulicę i numer"),
            Name = DataInputs("Imię"),
            Surname = DataInputs("Nazwisko"),
            Phone = DataInputs("numer telefonu"),

        });
        _repositoryDesigner.Save();
    }
    public void AddDeviceList(string txt)
    {
        Console.Clear();
        DeviceList();
        Console.WriteLine("\n" +
            "");
        _repositoryDeviceList.Add(new DeviceList()
        {
            Manufacturer = DeviceAdded("Podaj nazwę producenta urządzenia:  "),
            DeviceName = DeviceAdded("Podaj nazwę urządzenie:  "),
            PowerFactor = DeviceAdded("Podaj moc urządznie w kW:  ")
        });
        _repositoryDeviceList.Save();
    }

    public void Register()
    {
        int id = ObjectInput("Podaj id instalatora");
        int id2 = ObjectInput("Podaj id urządzenia");
        string serialNumber = InputString("Podaj numer seryjny urządzenia\n" +
            "");
        DateTime date = InputDateTime("Podaj datę uruchomienia urządzenia\n" +
            "");
        var installer = _provider.InstallerLauncher(id);
        var device = _provider.Device(id2);
        _repositoryDevice.Add(new Device()
        {
            Manufacturer = device.Manufacturer,
            DeviceName = $"{device.DeviceName}-{device.PowerFactor} kW",
            SerialNumber = serialNumber,
            CompanyLunching = $"Id: {installer.Id}-{installer.Company}-{installer.City}",
            LunchData = date,
        });
        _repositoryDevice.Save();
        Console.ReadLine();
    }

    string DataInputs(string txt)
    {
        string name2 = string.Empty;
        Console.WriteLine($"Podaj {txt}");
        if (txt == "nazwę firmy")
        {
            string name = Console.ReadLine();
            name2 = name.ToUpper();
            return name2;
        }
        else
        {
            string name = Console.ReadLine();
            name2 = char.ToUpper(name[0]) + name.Substring(1);
            return name2;
        }
    }
    public DateTime InputDateTime(string txt)
    {
        while (true)
        {
            Console.WriteLine($"Podaj {txt}");
            Console.WriteLine($"Podaj rok RRRR");
            string year = Console.ReadLine();
            Console.WriteLine($"Podaj miesiąc MM ");
            string month = Console.ReadLine();
            Console.WriteLine($"Podaj dzień DD ");
            string day = Console.ReadLine();
            if (DateTime.TryParse($"{year}-{month}-{day}", out DateTime date))
            {
                return date;
                break;
            }
            else
            {
                Console.WriteLine("Nie poprawna wartośc");
            }
        }
    }
    string AutorisationCode(string txt)
    {
        string autorisationCode = null;
        Console.WriteLine($"Podaj {txt}");
        autorisationCode = Console.ReadLine();
        while (true)
        {
            if (autorisationCode.Length != 6)
            {
                Console.WriteLine("Nie poprawna wartośc");
            }
            else
            {
                return autorisationCode;
                break;
            }
            Console.WriteLine($"Podaj {txt}");
            autorisationCode = Console.ReadLine();
        }
    }
    public string DeviceAdded(string txt)
    {
        Console.Write(txt);
        while (true)
        {
            string deviceName = Console.ReadLine();
            if (deviceName != null)
            {
                string dev = deviceName.ToUpper();
                return dev;
            }
        }
    }
    public void DeviceList()
    {
        var deviceList = _repositoryDeviceList.GetAll();
        Console.WriteLine("Lista urządzeń \n" +
            "");
        foreach (var device in deviceList)
        {
            Console.WriteLine($"ID: {device.Id} -- Producent: {device.Manufacturer}\n" +
                $"\t\t Nazwa urządzenia: {device.DeviceName} \n" +
                $"\t\t Moc urządzenia  : {device.PowerFactor} kW\n" +
                "");
        }
        Console.ReadLine();
    }
    int ObjectInput(string txt)
    {

        if (txt == "Podaj id instalatora")
        {
            _objectsReader.InstallerList();
        }
        else if (txt == "Podaj id urządzenia")
        {
            _objectsReader.DeviceL();
        }
        while (true)
        {
            Console.WriteLine(txt);
            string input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                return id;
            }
            else { Console.WriteLine("Nie poprawne ID"); }
        }
    }
    string InputString(string txt)
    {
        Console.WriteLine(txt);
        while (true)
        {
            string input = Console.ReadLine();
            int inputLenght = input.Length;
            if (inputLenght == 6)
            {
                return input;
                break;
            }
            else { Console.WriteLine("Nie poprawny numer"); }
        }
    }

}
