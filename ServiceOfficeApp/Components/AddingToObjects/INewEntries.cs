
namespace ServiceOfficeApp.Components.AddingToObjects;

public interface INewEntries
{
    void InatallerAdding();
    string DeviceAdded(string txt);
    void DesignerAdding();
    void AddDeviceList(string txt);
    void DeviceList();
    void Register();
    void WriteDataToFile(string filetxt, string txt);
}
