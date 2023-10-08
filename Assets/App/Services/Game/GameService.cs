using System.Collections.Generic;
using App.Scenes;
using App.Services.Game.Buildings;
using App.Services.Game.Config;
using App.Services.Game.Enums.Buildings;
using App.Services.PlayerProgress;
using App.Services.Popups;
using App.Services.Runners;
using App.Services.Scenes;
using UnityEngine;

namespace App.Services.Game
{
    public class GameService : IGameService
    {
        private ISceneService _sceneService;
        private IPlayerInventory _playerInventory;
        private IPopupService _popupService;
        private ICoroutineRunner _coroutineRunner;
        
        private GameData _gameData;
        private GameConfig _gameConfig;
        private GameStateId _gameStateId;

        public bool IsReadyForComplete => _playerInventory.Coins >= _gameConfig.CoinsForWin;

        public GameStateId GameStateId => _gameStateId;
        public GameData GameData => _gameData;

        public GameService(
            ISceneService sceneService, 
            IPlayerInventory playerInventory,
            IPopupService popupService,
            ICoroutineRunner coroutineRunner)
        {
            _sceneService = sceneService;
            _playerInventory = playerInventory;
            _popupService = popupService;
            _coroutineRunner = coroutineRunner;
        }

        public void StartGame(int minesCount)
        {
            _playerInventory.Clear();
            RestoreGame(minesCount);
        }

        public void RestoreGame(int minesCount)
        {
            LoadGameConfigIfNeed();
            InitNewGame(minesCount);
            _gameStateId = GameStateId.Game;
            _sceneService.LoadScene(SceneId.Game);
            _playerInventory.OnCoinsChanged += CheckForCompleteGame;
        }

        public void AbortGame()
        {
            _playerInventory.OnCoinsChanged -= CheckForCompleteGame;
            StopMachine();
            _gameData = null;
            _gameStateId = GameStateId.Menu;
            _sceneService.LoadScene(SceneId.MainMenu);
        }

        public void CompleteGame()
        {
            StopMachine();
            _playerInventory.OnCoinsChanged -= CheckForCompleteGame;
            _gameStateId = GameStateId.Menu;
            _playerInventory.SetCoins(0);
            if (_popupService.IsAnyPopupOpened)
                _popupService.ClosePopup();
            _popupService.Open(PopupId.Win, PopupWinCloseHandler);
        }

        public void LoadMainMenu()
        {
            _gameStateId = GameStateId.Menu;
            _sceneService.LoadScene(SceneId.MainMenu);
        }

        private void StopMachine()
        {
            foreach (var gameDataBuilding in _gameData.Buildings)
            foreach (var building in gameDataBuilding.Value)
                building.Stop();
        }

        private void PopupWinCloseHandler(PopupCloseResult pcr)
        {
            _sceneService.LoadScene(SceneId.MainMenu);
        }

        private void LoadGameConfigIfNeed()
        {
            _gameConfig ??= Resources.Load<GameConfigScriptableObject>("Configs/GameConfig").GameConfig;
        }

        private void InitNewGame(int minesCount)
        {
            _gameData = new GameData();
            
            _gameData.Buildings.Add(BuildingTypeId.Market,new List<IBuilding>{new Market(0, _gameConfig.Markets[0],_playerInventory)});
            _gameData.Buildings.Add(BuildingTypeId.Forge,new List<IBuilding>{new Forge(0, _gameConfig.Forges[0],_coroutineRunner, _playerInventory)});
            _gameData.Buildings.Add(BuildingTypeId.Mine,new List<IBuilding>());

            for (int i = 0; i < minesCount; i++)
                _gameData.Buildings[BuildingTypeId.Mine].Add(new Mine(i,_gameConfig.Mines[i],_coroutineRunner, _playerInventory));
        }
        
        private void CheckForCompleteGame()
        {
            if (IsReadyForComplete)
                CompleteGame();
        }

        
    }
}
