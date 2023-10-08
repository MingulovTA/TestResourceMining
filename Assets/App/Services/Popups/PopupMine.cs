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
        private const string GAMERESOURCE_ICON_PATH = "ResIcons/";
        
        [SerializeField] private Button _btnStart;
        [SerializeField] private Button _btnStop;
        [SerializeField] private Image _progressBar;
        [SerializeField] private Button _btnSelectResource;

        private GameObject _selectedResource;
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
            UpdateSelectedResourceView();
        }

        public void StartStopClick()
        {
            if (_mine.IsMining)
                _mine.StopMining();
            else
                _mine.StartMining();
            UpdateView();
        }

        public void ResourceClick()
        {
            _mine.SelectResource();
            UpdateSelectedResourceView();
            if (_mine.IsMining)
            {
                _mine.StopMining();
                UpdateView();
            }
        }

        private void UpdateSelectedResourceView()
        {
            if (_selectedResource!=null)
                Destroy(_selectedResource);

            _selectedResource = Resources.Load<GameObject>(GAMERESOURCE_ICON_PATH + _mine.GameResourceId);
            _selectedResource = Instantiate(_selectedResource, _btnSelectResource.transform);
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
