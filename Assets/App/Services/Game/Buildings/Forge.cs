using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using App.Services.Game.Config;
using App.Services.Game.Enums.Buildings;
using App.Services.Game.Enums.GameResources;
using App.Services.PlayerProgress;
using App.Services.Runners;
using UnityEngine;

namespace App.Services.Game.Buildings
{
    public class Forge : IBuilding
    {
        private ICoroutineRunner _coroutineRunner;
        private IPlayerInventory _playerInventory;
        
        private int _indexId;
        private ForgeSettings _forgeSettings;

        private List<ForgeCell> _prescription = new List<ForgeCell>{new ForgeCell(),new ForgeCell()};
        private GameResourceId _resultResource;
        private bool _isValidPrescription;
        private bool _isForgeing;
        private Coroutine _coroutine;
        private float _progress;
        
        public bool IsValidStep => _playerInventory.GetResourceCount(_prescription[0].GameResourceId) > 0 &&
                                   _playerInventory.GetResourceCount(_prescription[1].GameResourceId) > 0;

        public GameResourceId ResultResource => _resultResource;
        public bool IsValidPrescription => _isValidPrescription;
        public bool IsForgeing => _isForgeing;

        public BuildingTypeId BuildingTypeId => BuildingTypeId.Forge;

        public List<GameResourceId> Prescription => _prescription.Select(p=>p.GameResourceId).ToList();

        public event Action OnWorkingStateUpdated;

        public int IndexId => _indexId;
        public float Progress => _progress;

        public void Stop()
        {
            if (_isForgeing)
                _coroutineRunner.Stop(_coroutine);
        }

        public Forge(int indexId, ForgeSettings forgeSettings,ICoroutineRunner coroutineRunner, IPlayerInventory playerInventory)
        {
            _indexId = indexId;
            _forgeSettings = forgeSettings;
            _coroutineRunner = coroutineRunner;
            _playerInventory = playerInventory;
        }

        public void SelectPrescription(int index)
        {
            _prescription[index].Select();
            UpdatePrescriptions();
        }

        private void UpdatePrescriptions()
        {
            var validPrescription =_forgeSettings.Forges.FirstOrDefault(f =>
                f.Prescription[0] == _prescription[0].GameResourceId &&
                f.Prescription[1] == _prescription[1].GameResourceId ||
                f.Prescription[0] == _prescription[1].GameResourceId &&
                f.Prescription[1] == _prescription[0].GameResourceId);

            if (validPrescription == null)
            {
                _isValidPrescription = false;
            }
            else
            {
                _isValidPrescription = true;
                _resultResource = validPrescription.Result;
            }
        }

        public void StopForgeing()
        {
            if (!_isForgeing) return;
            _isForgeing = false;
            _coroutineRunner.Stop(_coroutine);
            OnWorkingStateUpdated?.Invoke();
        }

        public void StartForgeing()
        {
            if (_isForgeing||!IsValidStep) return;
            _isForgeing = true;
            _coroutine = _coroutineRunner.Run(Working());
            OnWorkingStateUpdated?.Invoke();
        }
        
        private IEnumerator Working()
        {
            float timer = 0;

            while (IsValidStep)
            {
                _progress = timer / _forgeSettings.ForgeTime;
                timer += Time.deltaTime;
                if (timer >= _forgeSettings.ForgeTime)
                {
                    _playerInventory.AddResource(_prescription[0].GameResourceId,-1);
                    _playerInventory.AddResource(_prescription[1].GameResourceId,-1);
                    _playerInventory.AddResource(_resultResource,1);
                    timer = 0;
                }

                yield return null;
            }

            StopForgeing();
        }


    }
}
