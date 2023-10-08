using App.Game.Buildings;
using App.Game.GameResources;
using App.Services.Game.Config.Marketing;
using App.Services.PlayerProgress;

namespace App.Services.Game.Buildings
{
    public class Market : IBuilding
    {
        private GameResourceId _gameResourceId;
        private int _gameResourceIdIndex;
        private PriceLine _priceLine;
        public bool IsValidTransaction => _priceLine!=null&&_playerInventory.GetResourceCount(_gameResourceId) > 0;
        
        private MarketSettings _marketSettings;
        private IPlayerInventory _playerInventory;
        
        public BuildingTypeId BuildingTypeId => BuildingTypeId.Market;
        public int Price => _priceLine.Price;
        public int IndexId { get; }
        public object GameResourceId => _gameResourceId;

        public void Stop() { }

        public Market(int indexId, MarketSettings marketSettings, IPlayerInventory playerInventory)
        {
            IndexId = indexId;
            _marketSettings = marketSettings;
            _playerInventory = playerInventory;
        }
        
        public void SelectResource()
        {
            _gameResourceIdIndex++;
            if (_gameResourceIdIndex >= _marketSettings.Price.Count)
                _gameResourceIdIndex = 0;
            _priceLine = _marketSettings.Price[_gameResourceIdIndex];
            _gameResourceId = _priceLine.GameResourceId;
        }

        public void Sell()
        {
            if (!IsValidTransaction) return;
            _playerInventory.AddResource(_gameResourceId,-1);
            _playerInventory.AddCoins(_priceLine.Price);
        }
    }
}
