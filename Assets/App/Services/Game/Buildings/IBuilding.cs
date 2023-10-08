using App.Services.Game.Enums.Buildings;

namespace App.Services.Game.Buildings
{
    public interface IBuilding
    {
        BuildingTypeId BuildingTypeId { get; }
        int IndexId { get; }

        void Stop();
    }
}
