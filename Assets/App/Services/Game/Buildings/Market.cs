using App.Game.Buildings;

namespace App.Services.Game.Buildings
{
    public class Market : IBuilding
    {
        public BuildingTypeId BuildingTypeId => BuildingTypeId.Market;
        public int IndexId { get; }
        public Market(int indexId)
        {
            IndexId = indexId;
        }
    }
}
