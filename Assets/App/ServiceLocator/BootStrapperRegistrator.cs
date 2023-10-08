using App.ServiceLocator.Container;
using App.ServiceLocator.Interfaces;
using App.Services.Game;
using App.Services.PlayerProgress;
using App.Services.Popups;
using App.Services.Runners;
using App.Services.Scenes;
using UnityEngine;

namespace App.ServiceLocator
{
    public class BootStrapperRegistrator: IBootStrapperRegistrator
    {
        private DiContainer _diContainer;
        public void InstallBindings(DiContainer diContainer)
        {
            _diContainer = diContainer;
            
            _diContainer.RegisterAsSingle<ICoroutineRunner>(CoroutineRunner());
            _diContainer.RegisterAsSingle<IPopupService>(PopupService());
            _diContainer.RegisterAsSingle<IPlayerProgressService>(new PlayerProgressService());
            _diContainer.RegisterAsSingle<ISceneService>(new SceneService());
            _diContainer.RegisterAsSingle<IGameService>(GameService());
            
            
            
            
            /*diContainer.RegisterAsSingle<IPopupRewardAds>(PopupRewardAds());            
            AppServiceLocator.RegisterAsSingle<IExternalCmdsService>(ExternalCmdsService());
            AppServiceLocator.RegisterAsSingle<IMuteService>(MuteService());
            AppServiceLocator.RegisterAsSingle<IAdsService>(AdsService());
            AppServiceLocator.RegisterAsSingle<ISoundService>(SoundService());
            AppServiceLocator.RegisterAsSingle<ILocalizationService>(LocalizationService());
            AppServiceLocator.RegisterAsSingle<ICheatService>(CheatService());*/
        }
        
        private CoroutineRunner CoroutineRunner()
        {
            GameObject go = new GameObject();
            Object.DontDestroyOnLoad(go);
            go.name = "CoroutineRunner";
            CoroutineRunner cr = go.AddComponent<CoroutineRunner>();
            return cr;
        }

        private PopupService PopupService()
        {
            string resPath = PopupContainer.POPUPS_CONTAINER_RESOURCE_PATH;
            PopupContainer popupContainerPrefab = Resources.Load<PopupContainer>(resPath);
            PopupContainer popupContainerInstance = Object.Instantiate(popupContainerPrefab);
            Object.DontDestroyOnLoad(popupContainerInstance);
            popupContainerInstance.name = "PopupContainer";
            
            PopupService popupService = new PopupService(popupContainerInstance);
            return popupService;
        }
        
        private GameService GameService()
        {
            GameService gameService = new GameService(_diContainer.Resolve<ISceneService>());
            return gameService;
        }

        /*private static IAdsService AdsService()
        {
            if (TargetStore.StoreId == StoreId.STORE_YANDEX)
                return new YandexAdsService(AppServiceLocator.Resolve<IExternalCmdsService>(), 
                    AppServiceLocator.Resolve<ICoroutineRunner>(),
                    AppServiceLocator.Resolve<IMuteService>());

            if (TargetStore.StoreId == StoreId.STORE_DISTRIBUTION)
                return new GameDistributionAdsService(AppServiceLocator.Resolve<IPopupRewardAds>(),
                    AppServiceLocator.Resolve<ICoroutineRunner>(),
                    AppServiceLocator.Resolve<IMuteService>());

            if (TargetStore.StoreId == StoreId.STORE_CRAZY)
                return new CrazyAdsService(AppServiceLocator.Resolve<IPopupRewardAds>(), AppServiceLocator.Resolve<ICoroutineRunner>());
            return new DummyAdsService();
        }




        private static IExternalCmdsService ExternalCmdsService()
        {
            GameObject go = new GameObject();
            Object.DontDestroyOnLoad(go);
            go.name = "ExternalCmdsService";
            ExternalCmdsService ecs = go.AddComponent<ExternalCmdsService>();
            return ecs;
        }

        private static IMuteService MuteService()
        {
            GameObject go = new GameObject();
            Object.DontDestroyOnLoad(go);
            go.name = "MuteService";
            MuteService ecs = go.AddComponent<MuteService>();
            return ecs;
        }

        private static ISoundService SoundService()
        {
            GameObject go = new GameObject();
            Object.DontDestroyOnLoad(go);
            go.name = "SoundService";
            SoundService ss = go.AddComponent<SoundService>();
            return ss;
        }

        private static ILocalizationService LocalizationService()
        {
            return new LocalizationService(AppServiceLocator.Resolve<IExternalCmdsService>(),AppServiceLocator.Resolve<ICoroutineRunner>());
        }

        private static ICheatService CheatService()
        {
            var cs = Resources.Load<CheatService>("CheatService");
            cs = Object.Instantiate(cs);
            Object.DontDestroyOnLoad(cs);
            return cs;
        }
        private static IPopupRewardAds PopupRewardAds()
        {
            var pra = Resources.Load<PopupRewardAds>("PopupRewardAds");
            pra = Object.Instantiate(pra);
            Object.DontDestroyOnLoad(pra);
            pra.Hide();
            return pra;
        }*/
    }
}
