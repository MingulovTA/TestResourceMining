using App.Game.Buildings;
using App.ServiceLocator.Container;
using App.Services.Game;
using App.Services.Game.Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace App.Services.Popups
{
    public class PopupMine : BasePopup
    {
        [SerializeField] private Button _btnStart;
        [SerializeField] private Button _btnStop;
        [SerializeField] private Image _progressBar;
        private IGameService _gameService;
        private Mine _mine;
        private void Awake()
        {
            _gameService = AppServiceLocator.Resolve<IGameService>();
            _mine = _gameService.GameData.GetBuilding<Mine>(BuildingTypeId.Mine);
        }
        
        private void OnEnable()
        {
            UpdateView();
        }

        public void StartStopClick()
        {
            if (_mine.IsMining)
                _mine.StopMining();
            else
                _mine.StartMining();
            UpdateView();
        }

        private void UpdateView()
        {
            _progressBar.fillAmount = 0;
            _btnStart.gameObject.SetActive(!_mine.IsMining);
            _btnStop.gameObject.SetActive(_mine.IsMining);
        }

        private void LateUpdate()
        {
            if (!_mine.IsMining) return;
            _progressBar.fillAmount = _mine.Progress;
        }

    }
}
