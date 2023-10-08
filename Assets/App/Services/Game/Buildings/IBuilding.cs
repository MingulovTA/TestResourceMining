using App.Game.Buildings;

namespace App.Services.Game.Buildings
{
    public interface IBuilding
    {
        BuildingTypeId BuildingTypeId { get; }
        int IndexId { get; }
    }
}
