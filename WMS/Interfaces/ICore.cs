using WMS.Handlers;

namespace WMS.Interfaces
{
    public interface ICore
    {
        void Run();

        IWindowHandler WindowHandler { get; }

        DataHandler DataHandler { get; }

    }
}
