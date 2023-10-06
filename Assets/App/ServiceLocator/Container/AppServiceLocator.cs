using App.ServiceLocator.Interfaces;

namespace App.ServiceLocator.Container
{
    public class AppServiceLocator
    {
        private static DiContainer _diContainer = new DiContainer();
        private static bool _isInited;

        public static bool IsInited => _isInited;

        public AppServiceLocator(IBootStrapperRegistrator bootStrapperRegistrator)
        {
            if (_isInited) return;
            bootStrapperRegistrator.InstallBindings(_diContainer);
            _isInited = true;
        }

        public static TService Resolve<TService>() where TService : IService => _diContainer.Resolve<TService>();
    }
}