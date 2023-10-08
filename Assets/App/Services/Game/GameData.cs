using System.Collections;
using System.Collections.Generic;
using App.Game.Buildings;
using App.Services.Game.Buildings;
using UnityEngine;

public class GameData
{
    public Dictionary<BuildingTypeId, List<IBuilding>> Buildings = new Dictionary<BuildingTypeId, List<IBuilding>>();
    public int SelectedBuildingIndex;
}
