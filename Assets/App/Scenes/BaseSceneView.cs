using App.ServiceLocator.Container;
using App.Services.Game;
using App.Services.Scenes;
using UnityEngine;

namespace App.Scenes
{
    public abstract class BaseSceneView : MonoBehaviour
    {
        [SerializeField] private GameStateId _gameStateId;

        protected IGameService _gameService;
        private ISceneService _sceneService;
        private void Awake()
        {
            _gameService = AppServiceLocator.Resolve<IGameService>();
            _sceneService = AppServiceLocator.Resolve<ISceneService>();
            if (_gameService.GameStateId==_gameStateId)
                Construct();
            else
                _sceneService.LoadScene(SceneId.EntryLoading);
        }

        protected  abstract void Construct();
    }
}