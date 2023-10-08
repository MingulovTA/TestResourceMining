using App.Game.Buildings;
using App.Services.Game.Config;

namespace App.Services.Game.Buildings
{
    public class Forge : IBuilding
    {
        private ForgeSettings _forgeSettings;
        public BuildingTypeId BuildingTypeId => BuildingTypeId.Forge;
        public int IndexId { get; }
        
        public void Stop()
        {
            
        }

        public Forge(int indexId, ForgeSettings forgeSettings)
        {
            IndexId = indexId;
            _forgeSettings = forgeSettings;
        }
    }
}
