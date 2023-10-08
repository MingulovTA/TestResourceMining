using System.Collections.Generic;
using App.Game.Buildings;
using App.Scenes;
using App.Services.Game.Buildings;
using App.Services.Game.Config;
using App.Services.Scenes;
using UnityEngine;

namespace App.Services.Game
{
    public class GameService : IGameService
    {
        private ISceneService _sceneService;
        private GameData _gameData;
        private GameConfig _gameConfig;
        private GameStateId _gameStateId;


        public GameStateId GameStateId => _gameStateId;
        public GameData GameData => _gameData;

        public GameService(ISceneService sceneService)
        {
            _sceneService = sceneService;
        }

        public void StartGame(int minesCount)
        {
            _gameData = new GameData();
            
            _gameData.Buildings.Add(BuildingTypeId.Market,new List<IBuilding>{new Market(0)});
            _gameData.Buildings.Add(BuildingTypeId.Forge,new List<IBuilding>{new Forge(0)});
            _gameData.Buildings.Add(BuildingTypeId.Mine,new List<IBuilding>());

            for (int i = 0; i < minesCount; i++)
                _gameData.Buildings[BuildingTypeId.Mine].Add(new Mine(i));
            
            _gameConfig = Resources.Load<GameConfigScriptableObject>("Configs/GameConfig").GameConfig;
            _gameStateId = GameStateId.Game;
            _sceneService.LoadScene(SceneId.Game);
        }


        public void RestoreGame()
        {
            _gameStateId = GameStateId.Game;
            _sceneService.LoadScene(SceneId.Game);
        }

        public void AbortGame()
        {
            _gameStateId = GameStateId.Menu;
            _sceneService.LoadScene(SceneId.MainMenu);
        }
    }
}
