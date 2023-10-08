using App.Game.Buildings;

namespace App.Services.Game.Buildings
{
    public class Mine : IBuilding
    {
        public BuildingTypeId BuildingTypeId => BuildingTypeId.Mine;
        public int IndexId { get; }
        public Mine(int indexId)
        {
            IndexId = indexId;
        }
    }
}