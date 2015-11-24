using System.Windows.Forms;

namespace WMS.Interfaces
{
    public interface IGui
    {
        void UpdateGuiElements();

        void UpdateLang(ILang lang);

    }
}
