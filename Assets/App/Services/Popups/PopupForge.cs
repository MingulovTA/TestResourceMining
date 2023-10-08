using System.Collections.Generic;
using App.Game.Buildings;
using App.Game.GameResources;
using App.ServiceLocator.Container;
using App.Services.Game;
using App.Services.Game.Buildings;
using App.Services.PlayerProgress;
using UnityEngine;
using UnityEngine.UI;

namespace App.Services.Popups
{
    public class PopupForge : BasePopup
    {
        private const string GAMERESOURCE_ICON_PATH = "ResIcons/";
        
        [SerializeField] private List<Button> _btnsResources;
        [SerializeField] private Button _btnResultResource;
        [SerializeField] private Button _btnStop;
        [SerializeField] private Button _btnStart;
        [SerializeField] private Image _progressBar;

        private List<GameObject> _prescriptionIcons = new List<GameObject>{null,null};
        private GameObject _resultIcon;
        private IGameService _gameService;
        private IPlayerInventory _playerInventory;
        private Forge _forge;
        private void Awake()
        {
            _gameService = AppServiceLocator.Resolve<IGameService>();
            _playerInventory = AppServiceLocator.Resolve<IPlayerInventory>();
            _forge = _gameService.GameData.GetBuilding<Forge>(BuildingTypeId.Forge);
        }
        
        private void OnEnable()
        {
            for (var i = 0; i < _btnsResources.Count; i++)
                UpdatePrescriptionView(i);
            UpdateResultView();
            UpdateView();
            _forge.OnWorkingStateUpdated += UpdateView;
            _playerInventory.OnInventoryChanged += InventoryChangedHandler;
        }



        private void OnDisable()
        {
            _forge.OnWorkingStateUpdated -= UpdateView;
            _playerInventory.OnInventoryChanged -= InventoryChangedHandler;
        }

        public void StartStopClick()
        {
            if (_forge.IsForgeing)
                _forge.StopForgeing();
            else
                _forge.StartForgeing();
        }

        public void ResourceClick(int i)
        {
            _forge.SelectPrescription(i);
            UpdatePrescriptionView(i);
            UpdateResultView();
        }

        private void UpdatePrescriptionView(int i)
        {
            if (_prescriptionIcons[i]!=null)
                Destroy(_prescriptionIcons[i]);
            _prescriptionIcons[i] = Resources.Load<GameObject>(GAMERESOURCE_ICON_PATH + _forge.Prescription[i]);
            _prescriptionIcons[i] = Instantiate(_prescriptionIcons[i], _btnsResources[i].transform);
        }

        private void UpdateResultView()
        {
            if (_resultIcon!=null)
                Destroy(_resultIcon);
            if (_forge.IsValidPrescription)
            {
                _resultIcon = Resources.Load<GameObject>(GAMERESOURCE_ICON_PATH + _forge.ResultResource);
                _resultIcon = Instantiate(_resultIcon, _btnResultResource.transform);
            }

            UpdateBtnStartView();
        }
        
        private void UpdateView()
        {
            _progressBar.fillAmount = 0;
            _btnStart.gameObject.SetActive(!_forge.IsForgeing);
            _btnStop.gameObject.SetActive(_forge.IsForgeing);

            foreach (var btnsResource in _btnsResources)
                btnsResource.interactable = !_forge.IsForgeing;
            UpdateBtnStartView();
        }

        private void UpdateBtnStartView()
        {
            _btnStart.interactable = _forge.IsValidPrescription&&_forge.IsValidStep;
        }
        
        private void InventoryChangedHandler(GameResourceId obj)
        {
            UpdateBtnStartView();
        }

        private void LateUpdate()
        {
            if (!_forge.IsForgeing) return;
            _progressBar.fillAmount = _forge.Progress;
        }
    }
}
