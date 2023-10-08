using App.ServiceLocator.Container;
using App.Services.Game;
using App.Services.PlayerProgress;
using App.Services.Popups;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scenes.MainMenu
{
    public class MainMenuSceneView : BaseSceneView
    {
        [SerializeField] private RadioGroupView _rgvMines;
        [SerializeField] private Button _btnContinue;
        
        private IGameService _gameService;
        private IPlayerInventory _playerInventory;
        
        protected override void Construct()
        {
            _gameService = AppServiceLocator.Resolve<IGameService>();
            _playerInventory = AppServiceLocator.Resolve<IPlayerInventory>();
        }

        private void Start()
        {
            _btnContinue.interactable = !_playerInventory.IsEmpty;
        }
        
        public void BtnStartClickHandler()
        {
            _gameService.StartGame(_rgvMines.CurrentItemIndex);
        }

        public void BtnContinueClickHandler()
        {
            _gameService.RestoreGame(_rgvMines.CurrentItemIndex);
        }

        public void BtnQuitClickHandler()
        {
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }
}
