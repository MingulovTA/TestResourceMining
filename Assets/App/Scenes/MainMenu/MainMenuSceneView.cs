using App.ServiceLocator.Container;
using App.Services.Game;
using App.Services.Popups;
using UnityEngine;

namespace App.Scenes.MainMenu
{
    public class MainMenuSceneView : BaseSceneView
    {
        [SerializeField] private RadioGroupView _rgvMines;
        
        private IGameService _gameService;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                AppServiceLocator.Resolve<IPopupService>().Open(PopupId.Forge);
        
            if (Input.GetKeyDown(KeyCode.Alpha2))
                AppServiceLocator.Resolve<IPopupService>().Open(PopupId.Market);
        
            if (Input.GetKeyDown(KeyCode.Alpha3))
                AppServiceLocator.Resolve<IPopupService>().Open(PopupId.Mine);
        
            if (Input.GetKeyDown(KeyCode.Alpha4))
                AppServiceLocator.Resolve<IPopupService>().Open(PopupId.Win);
        }

        protected override void Construct()
        {
            _gameService = AppServiceLocator.Resolve<IGameService>();
        }

        public void BtnStartClickHandler()
        {
            _gameService.StartGame(_rgvMines.CurrentItemIndex);
        }
    }
}
