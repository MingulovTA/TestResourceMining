using System;
using App.ServiceLocator.Interfaces;

namespace App.Services.PlayerProgress
{
    public interface IPlayerProgressService : IService
    {
        PlayerProgressData Data { get; }

        void AddCoins(int coins);
        
        event Action OnCoinsChanged;
        event Action OnInventoryChanged;
    }
}
