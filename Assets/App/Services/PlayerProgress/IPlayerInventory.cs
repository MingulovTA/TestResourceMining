using System;
using App.Game.GameResources;
using App.ServiceLocator.Interfaces;

namespace App.Services.PlayerProgress
{
    public interface IPlayerInventory : IService
    {
        int Coins { get; }
        event Action OnCoinsChanged;
        event Action<GameResourceId> OnInventoryChanged;
        int GetResourceCount(GameResourceId gameResourceId);
        void SetResource(GameResourceId gameResourceId, int count);
        void AddResource(GameResourceId gameResourceId, int count);

        void AddCoins(int coins);
        void SetCoins(int coins);
    }
}
