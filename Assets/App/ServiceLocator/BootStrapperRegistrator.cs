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
            _diContainer.RegisterAsSingle<IPlayerInventory>(new PlayerInventory());
            _diContainer.RegisterAsSingle<ISceneService>(new SceneService());
            _diContainer.RegisterAsSingle<IGameService>(GameService());
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
            GameService gameService = new GameService(
                _diContainer.Resolve<ISceneService>(),
                _diContainer.Resolve<IPlayerInventory>(),
                _diContainer.Resolve<IPopupService>(),
                _diContainer.Resolve<ICoroutineRunner>());
            return gameService;
        }
    }
}
