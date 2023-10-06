using App.ServiceLocator.Container;

namespace App.ServiceLocator.Interfaces
{
    public interface IBootStrapperRegistrator
    {
        public void InstallBindings(DiContainer diContainer);
    }
}