using System;
using App.ServiceLocator.Interfaces;
using App.Services.Game.Enums.GameResources;

namespace App.Services.PlayerProgress
{
    public interface IPlayerInventory : IService
    {
        int Coins { get; }
        int GetResourceCount(GameResourceId gameResourceId);
        
        bool IsEmpty { get; }
        
        event Action OnCoinsChanged;
        event Action<GameResourceId> OnInventoryChanged;
        
        void SetResource(GameResourceId gameResourceId, int count);
        void AddResource(GameResourceId gameResourceId, int count);

        void AddCoins(int coins);
        void SetCoins(int coins);
        void Clear();
    }
}
