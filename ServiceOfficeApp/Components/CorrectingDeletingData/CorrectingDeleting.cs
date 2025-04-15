using ServiceAndWarrantyRecorder.Data.Entities;
using ServiceOfficeApp.Components.ReadingObjectData;
using ServiceOfficeApp.Components.AddingToObjects;
using ServiceOfficeApp.Data;
using ServiceOfficeApp.Data.Entities;
using ServiceOfficeApp.Data.Repositories;
namespace ServiceOfficeApp.Components.CorrectingDeletingData;

public class CorrectingDeleting: ICorrectingDeleting
{
   
    private readonly IRepository<Installer> _repositoryInstaller;
    private readonly IRepository<Designer> _repositoryDesigner;
    private readonly IRepository<Device> _repositoryDevice;
    private readonly IRepository<DeviceList> _repositoryDeviceList;
    private readonly INewEntries _newEntries;
    private readonly IObjectsReader _objectsReader;

    public CorrectingDeleting(IRepository<Installer> repositoryInstaller, IRepository<Designer> repositoryDesigner,
        IRepository<DeviceList> repositoryDeviceList, IRepository<Device> repositoryDevice, 
        IObjectsReader objectsReader, INewEntries newEntries)
    {
        _repositoryInstaller = repositoryInstaller;
        _repositoryDesigner = repositoryDesigner;
        _repositoryDeviceList = repositoryDeviceList;
        _repositoryDevice = repositoryDevice;
        _objectsReader = objectsReader;
        _newEntries = newEntries;
        _repositoryInstaller.ItemDeleted += InfoInstallerDeleted;
    }
    void InfoInstallerDeleted(object? sender, Installer e)
    {
        _newEntries.WriteDataToFile("InstallerBackUp.txt", $"Usunięto instalatora {e.Company} from {sender?.GetType().Name}");
    }
    public void InstallerChange()
    {
        _objectsReader.InstallerDataReader();
        Console.WriteLine("\n" +
            "");
        var changeName = RenameInstaller("Podaj Id instalatora do zmiany  lub x w celu wyjścia \n" +
            "");
        Console.WriteLine($"{changeName.Id}--{changeName.Company}\n" +
        $"\t \t \t {changeName.Name}--{changeName.Surname}\n" +
        $"\t \t \t {changeName.ZipCode}--{changeName.City}\n" +
        $"\t \t \t                       {changeName.Phone}\n" +
        $"");
        ObjectRenamer();
        void ObjectRenamer()
        {
            MenuRenamer();
            bool Close = true;
            while (Close)
            {
                Console.WriteLine("Podaj Id wyboru");
                string choiceId = Console.ReadLine();
                switch (choiceId)
                {
                    case "1":
                        CompanyName();
                        break;
                    case "2":
                        InstallerName();
                        break;
                    case "3":
                        InstSurname();
                        break;
                    case "4":
                        InstCity();
                        break;
                    case "5":
                        InstStreet();
                        break;
                    case "6":
                        InstZipCode();
                        break;
                    case "7":
                        InstPhone();
                        break;
                    case "x":
                        Close = false;
                        break;

                }
            }
        }
        void CompanyName()
        {
            changeName.Company = DataInstallerInputs("nazwę firmy");
            InstSave();
            Console.WriteLine("");
        }
        void InstallerName()
        {
            changeName.Name = DataInstallerInputs(" Nowe imię \n" +
                ""); InstSave();
        }
        void InstSurname()
        {
            changeName.Surname = DataInstallerInputs("Nowe nazwisko\n" +
                ""); InstSave();
        }
        void InstCity()
        {
            changeName.City = DataInstallerInputs("Nową nazwę maista\n" +
                ""); InstSave();
        }
        void InstStreet()
        {
            changeName.Street = DataInstallerInputs("podaj nazwę ulicy\n" +
                ""); InstSave();
        }
        void InstZipCode()
        {
            changeName.ZipCode = DataInstallerInputs("kod pocztowy\n" +
                ""); InstSave();
        }
        void InstPhone()
        {
            changeName.Phone = DataInstallerInputs("Nr telefonu\n" +
                ""); InstSave();
        }
        void InstSave()
        {
            _repositoryInstaller.Save();
        }

    }
    public void DesignerChange()
    {
        _objectsReader.DesignerDataReader();
        Console.WriteLine("\n" +
            "");
        var changeName = RenameDesigner("Podaj Id Projrktanta do zmiany danych lub -x- w celu wyjścia ");

        Console.WriteLine($"{changeName.Id}--{changeName.Company}\n" +
       $"\t \t \t {changeName.Name}--{changeName.Surname}\n" +
       $"\t \t \t {changeName.ZipCode}--{changeName.City}\n" +
       $"\t \t \t                       {changeName.Phone}\n" +
       $"");
        ObjectRenamer();
        void ObjectRenamer()
        {
            MenuRenamer();

            bool Close = true;
            while (Close)
            {
                Console.WriteLine("Podaj Id wyboru");
                string choiceId = Console.ReadLine();
                switch (choiceId)
                {
                    case "1":
                        CompanyName();
                        break;
                    case "2":
                        InstallerName();
                        break;
                    case "3":
                        InstSurname();
                        break;
                    case "4":
                        InstCity();
                        break;
                    case "5":
                        InstStreet();
                        break;
                    case "6":
                        InstZipCode();
                        break;
                    case "7":
                        InstPhone();
                        break;
                    case "x":
                        Close = false;
                        break;

                }
            }
        }
        void CompanyName()
        {
            changeName.Company = DataInstallerInputs("nazwę firmy");
            InstSave();
            Console.WriteLine("");
        }
        void InstallerName()
        {
            changeName.Name = DataInstallerInputs(" Nowe imię \n" +
                ""); InstSave();
        }
        void InstSurname()
        {
            changeName.Surname = DataInstallerInputs("Nowe nazwisko\n" +
                ""); InstSave();
        }
        void InstCity()
        {
            changeName.City = DataInstallerInputs("Nową nazwę maista\n" +
                ""); InstSave();
        }
        void InstStreet()
        {
            changeName.Street = DataInstallerInputs("podaj nazwę ulicy\n" +
                ""); InstSave();
        }
        void InstZipCode()
        {
            changeName.ZipCode = DataInstallerInputs("kod pocztowy\n" +
                ""); InstSave();
        }
        void InstPhone()
        {
            changeName.Phone = DataInstallerInputs("Nr telefonu\n" +
                ""); InstSave();
        }
        void InstSave()
        {
            _repositoryDesigner.Save();
        }
    }

    public void InstallerDelete()
    {
        _objectsReader.InstallerDataReader();
        while (true)
        {
            Console.WriteLine("Podaj ID instalatora do usunięcia: ");
            string id = Console.ReadLine();
            if (id != null && int.TryParse(id, out int id2))
            {
                var installerList = _repositoryInstaller.GetAll();
                var installer = installerList.FirstOrDefault(x => x.Id.Value == id2);
                if (installer != null)
                {
                    _repositoryInstaller.Remove(installer);
                    _repositoryInstaller.Save();
                    break;
                }
                else
                {
                    Console.WriteLine("Nie znaleziono instalatora o podanym ID");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Podano niepoprawne ID");
            }
        }
    }

    public void DesignerDelete()
    {
        _objectsReader.DesignerDataReader();
        while (true)
        {
            Console.WriteLine("Podaj ID projektanta do usunięcia: ");
            string id = Console.ReadLine();
            if (id != null && int.TryParse(id, out int id2))
            {
                var installerList = _repositoryInstaller.GetAll();
                var installer = installerList.FirstOrDefault(x => x.Id.Value == id2);
                if (installer != null)
                {
                    _repositoryInstaller.Remove(installer);
                    _repositoryInstaller.Save();
                    break;
                }
                else
                {
                    Console.WriteLine("Nie znaleziono projektanta o podanym ID");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Podano niepoprawne ID");
            }
        }
    }

    public void DeviceChange()
    {
        _objectsReader.DeviceL();
        while (true)
        {
            Console.WriteLine("Podaj ID urządzenia do zmainy: ");
            string id = Console.ReadLine();
            if (id != null && int.TryParse(id, out int id2))
            {
                var deviceList = _repositoryDeviceList.GetAll();
                var device = deviceList.FirstOrDefault(x => x.Id.Value == id2);
                if (device != null)
                {
                    device.Manufacturer = _newEntries.DeviceAdded("Podaj nową nazwę producenta:  ");
                    device.DeviceName = _newEntries.DeviceAdded("Podaj nową nazwę urządzenia:  ");
                    device.PowerFactor = _newEntries.DeviceAdded("Podaj nową moc urządzenia w kW:  ");
                    _repositoryDeviceList.Save();

                    Console.WriteLine($"Zmieniono urządzenie:  {device.Id}");
                    Thread.Sleep(750);
                    break;
                }
                else
                {
                    Console.WriteLine("Nie znaleziono urządzenia o podanym ID");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Podano niepoprawne ID");
            }

        }
    }
    public void DeviceRemove()
    {
        _newEntries.DeviceList();
        while (true)
        {
            Console.WriteLine("Podaj ID urządzenia do usunięcia: ");
            string id = Console.ReadLine();
            if (id != null && int.TryParse(id, out int id2))
            {
                var deviceList = _repositoryDeviceList.GetAll();
                var device = deviceList.FirstOrDefault(x => x.Id.Value == id2);
                if (device != null)
                {
                    _repositoryDeviceList.Remove(device);
                    _repositoryDeviceList.Save();
                    Console.WriteLine($"Usunięto urządzenie: {device.Id}");
                    Thread.Sleep(750);
                    break;
                }
                else
                {
                    Console.WriteLine("Nie znaleziono urządzenia o podanym ID");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Podano niepoprawne ID");
            }

        }
    }

    Installer? RenameInstaller(string txt)
    {
        var rename = _repositoryInstaller.GetAll();
        int id = 0;
        while (true)
        {
            Console.WriteLine(txt);
            string Id = Console.ReadLine();
            if (int.TryParse(Id, out int id2))
            {
                id = id2;
                return rename.FirstOrDefault(x => x.Id.Value == id);
                break;
            }
            else
            {
                Console.WriteLine($"Nie poprawne Id: {Id}\n" +
                $"");
            }
        }
    }
    Designer? RenameDesigner(string txt)
    {
        var rename = _repositoryDesigner.GetAll();
        int id = 0;
        while (true)
        {
            Console.Write($"{txt}: ");
            string Id = Console.ReadLine();
            if (int.TryParse(Id, out int id2))
            {
                id = id2;
                return rename.FirstOrDefault(x => x.Id.Value == id);
                break;
            }
            else
            {
                Console.WriteLine($"Nie poprawne Id: {Id}\n" +
                $"");
            }
        }
    }

    string DataInstallerInputs(string txt)
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

    void MenuRenamer()
    {
        Console.WriteLine("Wybierz pozycję do poprawy\n" +
                "");
        Console.WriteLine("1 - Nazwa firmy        2 - Imię\n" +
                          "3 - Nazwisko           4 - Miasto\n" +
                          "5 - Ulica              6 - Kod pocztowy\n" +
                          "7 - nr telefonu        x - w celu wyjścia\n" +
                            "");
    }

}
