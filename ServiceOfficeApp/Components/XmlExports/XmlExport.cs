using ServiceAndWarrantyRecorder.Data.Entities;
using ServiceOfficeApp.Data.Entities;
using ServiceOfficeApp.Data.Repositories;
using System.Xml.Linq;

namespace ServiceOfficeApp.Components.XmlExports;

internal class XmlExport : IXmlExport
{
    private readonly IRepository<Installer> _installerRepository;
    private readonly IRepository<Designer> _designerRepository;
    private readonly IRepository<Device> _deviceRepository;

    public XmlExport(IRepository<Installer> installerRepository, IRepository<Designer> designerRepository,
        IRepository<DeviceList> deviceListRepository, IRepository<Device> deviceRepository)
    {
        _installerRepository = installerRepository;
        _designerRepository = designerRepository;
        _deviceRepository = deviceRepository;
    }
    public void InstallerXmlRecorder()
    {
        var installerRepository = _installerRepository.GetAll();
        var installerDocument = new XDocument();

        var installer = new XElement("Installers", installerRepository.Select(x => new XElement("Installer",
                new XAttribute("Company", x.Company),
                new XAttribute("Name", x.Name),
                new XAttribute("Surname", x.Surname),
                new XAttribute("ZipCode", x.ZipCode),
                new XAttribute("City", x.City),
                new XAttribute("Street", x.Street),
                new XAttribute("Phone", x.Phone),
                new XAttribute("Authorization", x.Authorization),
                new XAttribute("Date", x.Date)
        )));
        installerDocument.Add(installer);
        installerDocument.Save("Installers.xml");
    }
    public void DesignerXmlRecorder()
    {
        var designerRepository = _designerRepository.GetAll();
        var designerDocument = new XDocument();

        var designer = new XElement("Designers", designerRepository.Select(x => new XElement("Designer",
                new XAttribute("Company", x.Company),
                new XAttribute("Name", x.Name),
                new XAttribute("Surname", x.Surname),
                new XAttribute("ZipCode", x.ZipCode),
                new XAttribute("City", x.City),
                new XAttribute("Street", x.Street),
                new XAttribute("Phone", x.Phone)

        )));
        designerDocument.Add(designer);
        designerDocument.Save("Designer.xml");
    }

    public void DeviceXmlRecorder()
    {
        var deviceRepository = _deviceRepository.GetAll();
        var deviceDocument = new XDocument();

        var device = new XElement("Devices", deviceRepository.Select(x => new XElement("Device",
                new XAttribute("Company", x.Company),
                new XAttribute("Name", x.Name),
                new XAttribute("Surname", x.Surname),
                new XAttribute("ZipCode", x.ZipCode),
                new XAttribute("City", x.City),
                new XAttribute("Street", x.Street),
                new XAttribute("Phone", x.Phone)

        )));
        deviceDocument.Add(device);
        deviceDocument.Save("Device.xml");
    }

    public void InstallerQueryXml()
    {
        Console.WriteLine("podaj początek nazwy poszukiwnej firmy)");
        string company = Console.ReadLine();
        string companyName = company.ToUpper();
        var document = XDocument.Load("Installers.xml");
        var names = document
            .Element("Installers")?
            .Elements("Installer")
            .Where(x => x.Attribute("Company")?.Value.StartsWith($"{companyName}") == true);

        Console.Clear();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
        Console.ReadKey();

    }

    public void MenuXml()
    {
        bool Stop = true;
        while (Stop)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("- Urządzenia: Wprowadzanie  i działanie na urządzeniach -\n" +
                "" +
                "1 - Export instalatorów do xml                 2 - Export projektantów do xml \n" +
                "3 - Export Urzadzeń zarejestrowanych do xml    4 - Import installatorów \n" +
                "x - wyjście z menu\n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    InstallerXmlRecorder();
                    break;
                case "2":
                    DesignerXmlRecorder();
                    break;
                case "3":
                    DeviceXmlRecorder();
                    break;
                case "4":
                    InstallerQueryXml();
                    break;
                case "x":
                    Stop = false;
                    break;

            }
        }
    }
}
