
using ServiceOfficeApp.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace ServiceOfficeApp.Components.CsvReader;
public class CsvReader : ICsvReader
 {
    public List<Installer> ReadFileInstaller(string filename)
    {
     
        if (!File.Exists(filename))
        {
            return new List<Installer>();
        }
        else
        {
            Console.WriteLine("Baza istnieje");
            Console.ReadLine();
        }

        var installer = File.ReadAllLines(filename)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToInstaller();
        return installer.ToList();

    }

    public List<Designer> ReadFileDesigner(string filename)
    {

        if (!File.Exists(filename))
        {
            return new List<Designer>();
        }
        else
        {
            Console.WriteLine("Baza istnieje");
            Console.ReadLine();
        }

        var designer = File.ReadAllLines(filename)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToDesigner();
        return designer.ToList();
    }
    public List<DeviceList> ReadFileDeviceList(string filename)
    {

        if (!File.Exists(filename))
        {
            return new List<DeviceList>();
        }
        else
        {
            Console.WriteLine("Baza istnieje");
            Console.ReadLine();
        }

        var designer = File.ReadAllLines(filename)
            .Skip(1)
            .Where(x => x.Length > 1)
            .ToDeviceList();
        return designer.ToList();
    }

}
