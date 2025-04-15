using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ServiceAndWarrantyRecorder.Data.Entities;
using ServiceOfficeApp.Data.Entities;

namespace ServiceOfficeApp.Data;

public class ServiceOfficeDbContext : DbContext
{
    public ServiceOfficeDbContext(DbContextOptions<ServiceOfficeDbContext> options)
        : base(options)
    {
    }
    public DbSet<Installer> Installers { get; set; }
    public DbSet<Designer> Designers { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceList> DeviceLists { get; set; }
}
