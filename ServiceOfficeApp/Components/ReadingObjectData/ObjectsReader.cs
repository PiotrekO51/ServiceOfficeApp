
using ServiceOfficeApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using ServiceAndWarrantyRecorder.Data.Entities;
using ServiceOfficeApp.Data.Entities;

namespace ServiceOfficeApp.Components.ReadingObjectData;

public class ObjectsReader : IObjectsReader
{
    private readonly IRepository<Installer> _repositoryInstaller;
    private readonly IRepository<Designer> _repositoryDesigner;
    private readonly IRepository<Device> _repositoryDevice;
    private readonly IRepository<DeviceList> _repositoryDeviceList;

    public ObjectsReader(IRepository<Installer> repositoryInstaller, IRepository<Designer> repositoryDesigner,
        IRepository<DeviceList> repositoryDeviceList, IRepository<Device> repositoryDevice)
    {

        _repositoryInstaller = repositoryInstaller;
        _repositoryDesigner = repositoryDesigner;
        _repositoryDeviceList = repositoryDeviceList;
        _repositoryDevice = repositoryDevice;
    }

    public void InstallerDataReader()
    {
        var installer = _repositoryInstaller.GetAll();

        if (installer != null)
        {

            foreach (var item in installer)
            {
                DateTime date = item.Date;
                string onlydate = date.ToString("yyyy-MMMM-dd-dddd");
                Console.WriteLine($"Id: {item.Id}, Firma: {item.Company}\n" +
                    $"\n" +
                    $"\t\t Adres:{item.City},\t Ulica: {item.Street}\n" +
                    $"\t\t Nr Uprawnień: {item.Authorization},\t Data szkolenia: {onlydate}\n" +
                    $"\n" +
                    $"");
            }
            Console.ReadLine();
        }
        else { Console.WriteLine("Baza jest pusta"); }
    }
    public void DesignerDataReader()
    {
        var designer = _repositoryDesigner.GetAll();

        if (designer != null)
        {
            foreach (var item in designer)
            {
                Console.WriteLine($"Id: {item.Id}, Firma: {item.Company}\n" +
                    $"\n" +
                    $"\t\t      Adres:{item.City}, \t     Ulica: {item.Street}\n" +
                    $"\t\t           Imie: {item.Name}, \t         Nazwisko: {item.Surname}" +
                    $"\n" +
                    $"");
            }
            Console.ReadLine();
        }
        else { Console.WriteLine("Baza jest pusta"); }
    }
    public  void InstallerList()
    {
        var installerList = _repositoryInstaller.GetAll();
        foreach (var inst in installerList)
        {
            Console.WriteLine($"Id: {inst.Id},        Name: {inst.Company}\n" +
               $" \t\t        Imię: {inst.Name}\t Nazwosko: {inst.Surname}\n" +
               $" \t\t        City: {inst.City}\n" +
               $"");
        }
    }
    public void DeviceList()
    {
        Console.Clear();
        var deviceList = _repositoryDevice.GetAll();
        {
            int count = deviceList.Count();
            if (count != 0)
            {
                foreach (var dev in deviceList)
                {
                    Console.WriteLine($"ID: {dev.Id} - {dev.Manufacturer}\n" +
                        $"\t\t Nazwa urządzenia             : {dev.DeviceName} \n" +
                        $"\t\t Numer seryjny                : {dev.SerialNumber}\n" +
                        $"\t\t Data uruchomienia            : {dev.LunchData.ToString("yyyy/MM/dd/dddd")}\n" +
                        $"\t\t Nazwa furmy uruchamiającej   : {dev.CompanyLunching}\n" +
                        "");
                }
            }
            else { Console.WriteLine("Lista jest pusta"); Thread.Sleep(2000); }
        }
        Console.ReadLine();
    }
    public void DeviceL()
    {
        var deviceList = _repositoryDeviceList.GetAll();
        {
            foreach (var dev in deviceList)
            {
                Console.WriteLine($"ID: {dev.Id} - {dev.Manufacturer}\n" +
                    $"\t\t {dev.DeviceName} - {dev.PowerFactor} kW \n" +
                    "");
            }
        }
        Console.ReadLine();
    }

    public void Filtration(string txt)
    {
        Console.WriteLine($"Podaj {txt}");
        string input1 = Console.ReadLine();
        string input = input1.ToUpper();    
        if (txt == "numer seryjny")
        {
            List<Device> deviceList = _repositoryDevice.GetAll()
                .Where(x => x.SerialNumber == input)
                .ToList();
             
            if (deviceList != null)
            {
                Console.Clear();
                foreach (var dev in deviceList)
                {
                    Console.WriteLine($"ID: {dev.Id} - {dev.Manufacturer}\n" +
                            $"\t\t Nazwa urządzenia             : {dev.DeviceName} \n" +
                            $"\t\t Numer seryjny                : {dev.SerialNumber}\n" +
                            $"\t\t Data uruchomienia            : {dev.LunchData.ToString("yyyy/MM/dd/dddd")}\n" +
                            $"\t\t Nazwa furmy uruchamiającej   : {dev.CompanyLunching}\n" +
                            "");
                }
                Console.ReadLine(); 
            }
            else 
            { Console.WriteLine("Lista jest pusta"); Thread.Sleep(2000); }
        }
        else if (txt == "nazwę instalatora")
        {
            List<Device> deviceList = _repositoryDevice.GetAll()
                .Where(x => x.CompanyLunching.StartsWith(input))
                .ToList();

            if (deviceList != null)
            {
                Console.Clear();
                foreach (var dev in deviceList)
                {
                    Console.WriteLine($"ID: {dev.Id} - {dev.Manufacturer}\n" +
                            $"\t\t Nazwa urządzenia             : {dev.DeviceName} \n" +
                            $"\t\t Numer seryjny                : {dev.SerialNumber}\n" +
                            $"\t\t Data uruchomienia            : {dev.LunchData.ToString("yyyy/MM/dd/dddd")}\n" +
                            $"\t\t Nazwa furmy uruchamiającej   : {dev.CompanyLunching}\n" +
                            "");
                }
                Console.ReadLine();
            }
            else
            { Console.WriteLine("Lista jest pusta"); Thread.Sleep(2000); }
        }
    }  
}
