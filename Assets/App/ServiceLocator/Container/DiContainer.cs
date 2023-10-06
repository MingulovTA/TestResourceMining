using App.ServiceLocator.Interfaces;

namespace App.ServiceLocator.Container
{
    public class DiContainer
    {
        public void RegisterAsSingle<TService>(TService implementation) where TService: IService
        {
            Implementation<TService>.ServiceInstance = implementation;
        }
        
        public TService Resolve<TService>() where TService:IService
        {
            return Implementation<TService>.ServiceInstance;
        }

        private class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}