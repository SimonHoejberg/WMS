
namespace WMS.Interfaces
{
    /// <summary>
    /// An interface the main form implements
    /// </summary>
    public interface IMain
    {
        ICore Core { set; }

        void UpdatePics(bool da);

        void UpdateLang();
    }
}
