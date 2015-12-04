
namespace WMS.Interfaces
{
    /// <summary>
    /// An interface the every gui / form but the main form implements 
    /// </summary>
    public interface IGui
    {
        void UpdateGuiElements();

        void UpdateLang();

    }
}
