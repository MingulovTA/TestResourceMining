using App.Game.Buildings;
using UnityEngine;

namespace App.Services.Game.Buildings
{
    public class Forge : IBuilding
    {
        public BuildingTypeId BuildingTypeId => BuildingTypeId.Forge;
        public int IndexId { get; }
        public Forge(int indexId)
        {
            IndexId = indexId;
        }
    }
}
