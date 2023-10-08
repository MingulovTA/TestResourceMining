using App.ServiceLocator.Container;
using App.Services.Game;
using App.Services.Game.Buildings;
using App.Services.Game.Enums.Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace App.Services.Popups
{
    public class PopupMarket : BasePopup
    {
        [SerializeField] private Button _btnSell;
        [SerializeField] private Button _btnResource;
        [SerializeField] private Text _price;
        
        private GameObject _selectedResource;
        private IGameService _gameService;
        private Market _market;
        private void Awake()
        {
            _gameService = AppServiceLocator.Resolve<IGameService>();
            _market = _gameService.GameData.GetBuilding<Market>(BuildingTypeId.Market);
        }
        
        private void OnEnable()
        {
            UpdateBtnSellView();
            UpdateSelectedResourceView();
            UpdatePriceView();
        }
        public void SellClick()
        {
            _market.Sell();
            UpdateBtnSellView();
            UpdatePriceView();
        }

        public void SelectResourceClick()
        {
            _market.SelectResource();
            UpdateSelectedResourceView();
            UpdateBtnSellView();
            UpdatePriceView();
        }
        
        private void UpdateBtnSellView()
        {
            _btnSell.interactable = _market.IsValidTransaction;
        }

        private void UpdatePriceView()
        {
            _price.text = _market.IsValidTransaction ? _market.Price.ToString() : "Not required";
        }
        
        private void UpdateSelectedResourceView()
        {
            if (_selectedResource!=null)
                Destroy(_selectedResource);
            _selectedResource = Resources.Load<GameObject>(GameConsts.GameResourceIconsPath + _market.GameResourceId);
            _selectedResource = Instantiate(_selectedResource, _btnResource.transform);
        }
    }
}
