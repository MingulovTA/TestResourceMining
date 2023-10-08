using System;
using App.Services.Game.Enums.GameResources;

namespace App.Services.PlayerProgress
{
    [Serializable]
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