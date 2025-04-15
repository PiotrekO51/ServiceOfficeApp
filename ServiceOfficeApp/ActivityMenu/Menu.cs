using ServiceOfficeApp.Components.ReadingObjectData;
using ServiceOfficeApp.Components.AddingToObjects;
using ServiceOfficeApp.Data.Entities;
using ServiceOfficeApp.Components.CorrectingDeletingData;

namespace ServiceOfficeApp.ActivityMenu;

public class Menu : IMenu
{
    private readonly ICorrectingDeleting _correctingDeleting;
    private readonly IObjectsReader _objectsReader;
    private readonly INewEntries _newEntries;
    public Menu(IObjectsReader objectsReader, INewEntries newEntries, ICorrectingDeleting correctingDeleting)
    {
        _correctingDeleting = correctingDeleting;
        _objectsReader = objectsReader;
        _newEntries = newEntries;
    }
    public void MenuStart()
    {
        bool Close = true;
        while (Close)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" ZARZĄDZANIE DANYMI BAZY \n" +
                "");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Wybierz odpowiednie ID  lub -x-  w celu opuszczenia menu czynność \n" +
            "\n" +
            "1 - Baza instalatorów                                  2 - Baza projektantów\n" +
            "3 - Dodawanie Instalatorów                             4 - Dodawanie Projektantów\n" +
            "5 - Poprawianie danych instalatorów i prokektantów     x - WYJSCIE Z PROGRAMU \n" +
            "6 - Usuwanie z bazy \n" +
            "\n" +
            "");

            Console.ForegroundColor = ConsoleColor.White;


            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _objectsReader.InstallerDataReader();
                    break;
                case "2":
                    _objectsReader.DesignerDataReader();
                    break;
                case "3":
                    _newEntries.InatallerAdding();
                    break;
                case "4":
                    _newEntries.DesignerAdding();
                    break;
                case "5":
                    ChangeName();
                    break;
                case "6":
                    DeleteObject();
                    break;
                case "x":
                    Close = false;
                    break;

            }
        }
    }

    public void DeviceRegisterMenu()
    {
        bool Stop = true;
        while (Stop)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("- MODUŁ REJESTRACJI URZĄDZEŃ URUCHOMIONYCH -\n" +
                "\v" +
                "" +
                "1 - Lista urządzeń zarejestrowanych       2 - Rejestracja urządzeń \n" +
                "x  - wyjście z menu ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _objectsReader.DeviceList();
                    break;
                case "2":
                    _newEntries.Register();
                    break;
                case "x":
                    Stop = false;
                    break;
            }
        }
    }

    public void ChangeName()
    {
        bool Stop = true;
        while (Stop)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("- MODUŁ POPRAWIANIA DANYCH -\n" +
                "\v" +
                "" +
                "1 - poprawianie danych instalatora       2 - poprawianie danych projektanta \n" +
                "x  - wyjście z menu ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _correctingDeleting.InstallerChange();
                    break;
                case "2":
                    _correctingDeleting.DesignerChange();
                    break;
                case "x":
                    Stop = false;
                    break;

            }
        }

    }
   public  void DeleteObject()
    {
        bool Stop = true;
        while (Stop)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("- Usuwanie danych z bazy -\n" +
                "\v" +
                "" +
                "1 - Usuwanie danych instalatora       2 - Usuwanie danych projektanta \n" +
                "x  - wyjście z menu ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _correctingDeleting.InstallerDelete();
                    break;
                case "2":
                    _correctingDeleting.DesignerDelete();
                    break;
                case "x":
                    Stop = false;
                    break;

            }
        }
    }


    public void DewiceOperations()
    {
        string password = Password();
        bool Stop = true;
        while (Stop)
        {
            Console.Clear();
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("- Urządzenia: Wprowadzanie  i działanie na urządzeniach -\n" +
                "" +
                "1 - Lista urządzeń                             2 - Dodawanie urządzeń \n" +
                "3 - Poprawianie danych urzadzenia              4 - Usuwanie urządzeń \n" +
                "x - wyjście z menu \n" +
                "");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    _objectsReader.DeviceL();
                    break;
                case "2":
                    _newEntries.AddDeviceList(password);
                    break;
                case "3":
                    _correctingDeleting.DeviceChange();
                    break;
                case "4":
                    _correctingDeleting.DeviceRemove();
                    break;
                case "x":
                    Stop = false;
                    break;

            }
        }

    }
    string Password()
    {
        string pass3 = null;
        Console.Write("Podaj hasło:   ");
        string pass = Console.ReadLine();
        string pass2 = pass.ToUpper();
        if (pass2 != null && pass2 == "123PO")
        {
            Console.WriteLine("Hasło poprawne");
            Thread.Sleep(750);
            pass3 = pass2;
        }
        else
        {
            Console.WriteLine("Nie poprawne HASŁO");
            Thread.Sleep(750);
        }
        return pass3;
    }
}



