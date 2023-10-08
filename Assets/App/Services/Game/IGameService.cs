using App.ServiceLocator.Interfaces;

namespace App.Services.Game
{
    public interface IGameService : IService
    {
        GameStateId GameStateId { get; }
        GameData GameData { get; }
        void StartGame(int minesCount);
        void RestoreGame();
        void AbortGame();
    }
}
