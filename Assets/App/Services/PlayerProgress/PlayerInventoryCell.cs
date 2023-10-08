using App.Game.GameResources;

namespace App.Services.PlayerProgress
{
    public class PlayerInventoryCell
    {
        public GameResourceId GameResourceId;
        public int Count;

        public PlayerInventoryCell(GameResourceId gameResourceId, int count)
        {
            GameResourceId = gameResourceId;
            Count = count;
        }
    }
}