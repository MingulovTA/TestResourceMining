using App.ServiceLocator.Container;
using App.Services.Game;
using UnityEngine;

namespace App.Scenes
{
    public abstract class BaseSceneView : MonoBehaviour
    {
        [SerializeField] private GameStateId _gameStateId;

        protected IGameService _gameService;
        private void Awake()
        {
            _gameService = AppServiceLocator.Resolve<IGameService>();
            if (_gameService.GameStateId==_gameStateId)
                Construct();
            else
                _gameService.AbortGame();
        }

        protected  abstract void Construct();
    }
}