using ServiceOfficeApp.ActivityMenu;
using ServiceOfficeApp.Components.ImportCsvTooSql;
using ServiceOfficeApp.Data;
namespace ServiceOfficeApp;

public class App: IApp
{
    private readonly ServiceOfficeDbContext _swDbContext;
    private readonly ICsvImporter _csvImporter;
    private readonly IMenu _menu;

    public App(ServiceOfficeDbContext swDbContext, ICsvImporter csvImporter, IMenu menu)
    {
        _menu = menu;
        _swDbContext = swDbContext;
        _csvImporter = csvImporter;
        _swDbContext.Database.EnsureCreated();
    }

    public void RUN()
    {
        _csvImporter.InstallerAdderTooSql();
        _csvImporter.DesignerAdderTooSql();
        _csvImporter.DeviceListAdderTooSql();

        Console.WriteLine("Witamy w programie --BAZA INSTALATORÓW I URRZĄDZEŃ-- \n" +
           "");

        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("MENU WYBORU \n" +
                "Wybierz ID  lub - x -  w celu rozpoczęcia czynność \n" +
                "\n" +
                "1 - PRACA Z INSTALATOREM i PROJEKTANTEM \n" +
                "2 - REJESTRACJA URZĄDZEŃ \n" +
                "3 - ADMINISTRACJA \n" +
                "x - Wyjście z programu" +

                "");


            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _menu.MenuStart();
                    break;
                case "2":
                    _menu.DeviceRegisterMenu();
                    break;
                case "3":
                    _menu.DewiceOperations();
                    break;

                case "x":
                    Close = false;
                    break;
            }
        }
    }
}
