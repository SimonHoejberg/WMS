
namespace WMS.Interfaces
{
    public interface IGui
    {
        void UpdateGuiElements();

        void UpdateLang(ILang lang);

        string GetTypeOfWindow();
    }
}
