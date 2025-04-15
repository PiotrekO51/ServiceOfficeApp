using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using ServiceOfficeApp.Data.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceOfficeApp.Components.CsvReader;

public static class InstallerExtensions
{
    public static IEnumerable<Installer> ToInstaller(this IEnumerable<string> sources)
    {
        foreach (var line in sources)
        {
            var columns = line.Split(',');
            {
                yield return new Installer
                {
                    Company = columns[0],
                    ZipCode = columns[1],
                    City = columns[2],
                    Street = columns[3],
                    Name = columns[4],
                    Surname = columns[5],
                    Phone = columns[6],
                    Authorization = columns[7],
                    Date = DateTime.Parse(columns[8]),
                    
                }; Console.WriteLine(columns[0]); Thread.Sleep(20);
            }
        }
    }

     public static IEnumerable<Designer> ToDesigner(this IEnumerable<string> sources)
    {
        foreach (var line in sources)
        {
            var columns = line.Split(',');
            {
                yield return new Designer
                {
                    Company = columns[0],
                    ZipCode = columns[1],
                    City = columns[2],
                    Street = columns[3],
                    Name = columns[4],
                    Surname = columns?[5],
                    Phone = columns?[6],
                    
                    
                }; Console.WriteLine(columns[0]); Thread.Sleep(20);
            }
        }
    }
    public static IEnumerable<DeviceList> ToDeviceList(this IEnumerable<string> sources)
    {
        foreach (var line in sources)
        {
            var columns = line.Split(',');
            {
                yield return new DeviceList
                {
                    Manufacturer = columns[0],
                    DeviceName= columns[1],
                    PowerFactor = columns[2],
                }; Console.WriteLine($"{columns[0]}--{columns[1]}"); Thread.Sleep(20);
            }
        }
    }
}
