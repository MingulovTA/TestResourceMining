using App.Game.Buildings;
using App.Services.Game.Config.Marketing;

namespace App.Services.Game.Buildings
{
    public class Market : IBuilding
    {
        private MarketSettings _marketSettings;
        public BuildingTypeId BuildingTypeId => BuildingTypeId.Market;
        public int IndexId { get; }
        public Market(int indexId, MarketSettings marketSettings)
        {
            IndexId = indexId;
            _marketSettings = marketSettings;
        }
    }
}
