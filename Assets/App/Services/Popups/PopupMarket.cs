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
        private const string GAMERESOURCE_ICON_PATH = "ResIcons/";
        
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
            _selectedResource = Resources.Load<GameObject>(GAMERESOURCE_ICON_PATH + _market.GameResourceId);
            _selectedResource = Instantiate(_selectedResource, _btnResource.transform);
        }
    }
}
