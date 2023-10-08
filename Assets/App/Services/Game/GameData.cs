using System.Collections.Generic;
using App.Game.Buildings;
using App.Services.Game.Buildings;

namespace App.Services.Game
{
    public class GameData
    {
        public Dictionary<BuildingTypeId, List<IBuilding>> Buildings = new Dictionary<BuildingTypeId, List<IBuilding>>();
        public int SelectedBuildingIndex;

        public T GetBuilding <T>(BuildingTypeId buildingTypeId) where T : class =>
            Buildings[buildingTypeId][SelectedBuildingIndex] as T;
    }
}
