
namespace WMS.Interfaces
{
    /// <summary>
    /// An interface that a windowhandler must implement, which implements the IMenuWindows interface
    /// </summary>
    public interface IWindowHandler : IMenuWindows
    {
        void Update(object caller);

        void Run();

        void Exit(string error);

        void ChangeLang(ILang lang);
    }
}
