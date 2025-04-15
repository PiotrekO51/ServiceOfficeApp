using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceOfficeApp.Components.DataProviders;
using ServiceOfficeApp.Components.AddingToObjects;
using ServiceOfficeApp;
using ServiceOfficeApp.ActivityMenu;
using ServiceOfficeApp.Components.ReadingObjectData;
using ServiceOfficeApp.Components.CsvReader;
using ServiceOfficeApp.Components.ImportCsvTooSql;
using ServiceOfficeApp.Data;
using ServiceOfficeApp.Data.Entities;
using ServiceOfficeApp.Data.Repositories;
using ServiceAndWarrantyRecorder.Data.Entities;
using ServiceOfficeApp.Components.CorrectingDeletingData;


var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IMenu,  Menu>();
services.AddSingleton<ICsvReader, CsvReader>();
services.AddSingleton<IProvider, Provider>();
services.AddSingleton<INewEntries, NewEntries>();
services.AddSingleton<ICsvImporter, CsvImporter>();
services.AddSingleton<IObjectsReader, ObjectsReader>();
services.AddSingleton<ICorrectingDeleting, CorrectingDeleting>();
services.AddSingleton<IRepository<Device>, SqlRepository<Device>>();
services.AddSingleton<IRepository<Designer>, SqlRepository<Designer>>();
services.AddSingleton<IRepository<Installer>, SqlRepository<Installer>>();
services.AddSingleton<IRepository<DeviceList>, SqlRepository<DeviceList>>();
services.AddDbContext<ServiceOfficeDbContext>(options => options.UseSqlServer("Data Source =.\\SQLEXPRESS02; Initial Catalog = ServiceOfficeApp; Integrated Security = True; Trust Server Certificate=True"));
var serviceProvider =  services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.RUN();

