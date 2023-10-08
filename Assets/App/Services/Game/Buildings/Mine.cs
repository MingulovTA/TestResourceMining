using System.Collections;
using System.Linq;
using App.Services.Game.Config;
using App.Services.Game.Enums.Buildings;
using App.Services.Game.Enums.GameResources;
using App.Services.PlayerProgress;
using App.Services.Runners;
using UnityEngine;

namespace App.Services.Game.Buildings
{
    public class Mine : IBuilding
    {
        private ICoroutineRunner _coroutineRunner;
        private IPlayerInventory _playerInventory;
        
        private int _indexId;
        private MineSettings _mineSettings;
        private GameResourceId _gameResourceId;
        private int _gameResourceIdIndex;
        private bool _isMining;
        private Coroutine _coroutine;
        private float _progress;

        public BuildingTypeId BuildingTypeId => BuildingTypeId.Mine;
        public int IndexId => _indexId;
        
        public bool IsMining => _isMining;
        public GameResourceId GameResourceId => _gameResourceId;
        public float Progress => _progress;

        public Mine(int indexId, MineSettings mineSettings, ICoroutineRunner coroutineRunner, IPlayerInventory playerInventory)
        {
            _indexId = indexId;
            _mineSettings = mineSettings;
            _coroutineRunner = coroutineRunner;
            _playerInventory = playerInventory;
            SelectResource();
        }
        
        public void Stop()
        {
            if (_isMining)
                _coroutineRunner.Stop(_coroutine);
        }

        public void SelectResource()
        {
            _gameResourceIdIndex++;
            if (_gameResourceIdIndex >= _mineSettings.GameResourceIds.Count)
                _gameResourceIdIndex = 0;
            _gameResourceId = _mineSettings.GameResourceIds[_gameResourceIdIndex];
        }

        public void StartMining()
        {
            if (_isMining) return;
            _isMining = true;
            _coroutine = _coroutineRunner.Run(Mining());
        }

        public void StopMining()
        {
            if (!_isMining) return;
            _isMining = false;
            _coroutineRunner.Stop(_coroutine);
        }

        private IEnumerator Mining()
        {
            float timer = 0;
            
            while (true)
            {
                _progress = timer / _mineSettings.MineTime;
                timer += Time.deltaTime;
                if (timer >= _mineSettings.MineTime)
                {
                    _playerInventory.AddResource(_gameResourceId,1);
                    timer = 0;
                }
                yield return null;
            }
        }
    }
}