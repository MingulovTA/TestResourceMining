using System;
using System.Collections.Generic;
using System.Linq;
using App.Game.GameResources;
using UnityEngine;

namespace App.Services.PlayerProgress
{
    public class PlayerInventory : IPlayerInventory
    {
        private const string PREFS_KEY_INVENTORY = "com.PlayerProgress.Inventory";
        private const string PREFS_KEY_COINS = "com.PlayerProgress.Coins";
        
        private PlayerInventoryData _data;
        private int _coins;
        private Dictionary<GameResourceId, int> _resources = new Dictionary<GameResourceId, int>();

        public int Coins => _coins;

        public event Action OnCoinsChanged;
        public event Action<GameResourceId> OnInventoryChanged;

        public PlayerInventory()
        {
            _data = new PlayerInventoryData();

            foreach (var gameResourceId in Enum.GetValues(typeof(GameResourceId)).Cast<GameResourceId>())
            {
                _resources.Add(gameResourceId,0);
                _data.Cells.Add(new PlayerInventoryCell(gameResourceId,0));
            }

            if (PlayerPrefs.HasKey(PREFS_KEY_INVENTORY))
                LoadAll();
            else
                SaveAll();
        }
        
        public int GetResourceCount(GameResourceId gameResourceId)
        {
            return _resources[gameResourceId];
        }

        public void SetResource(GameResourceId gameResourceId, int count)
        {
            _resources[gameResourceId] = count;
            SaveInventory();
            OnInventoryChanged?.Invoke(gameResourceId);
        }
        
        public void AddResource(GameResourceId gameResourceId, int count)
        {
            _resources[gameResourceId] += count;
            SaveInventory();
            OnInventoryChanged?.Invoke(gameResourceId);
        }
        
        public void AddCoins(int coins)
        {
            _coins += coins;
            SaveCoins();
            OnCoinsChanged?.Invoke();
        }
        
        public void SetCoins(int coins)
        {
            _coins = coins;
            SaveCoins();
            OnCoinsChanged?.Invoke();
        }

        private void SaveAll()
        {
            SaveInventory();
            SaveCoins();
        }

        private void LoadAll()
        {
            LoadInventory();
            LoadCoins();
        }
        
        private void LoadInventory()
        {
            string json = PlayerPrefs.GetString(PREFS_KEY_INVENTORY);
            _data = JsonUtility.FromJson<PlayerInventoryData>(json);
            foreach (var cell in _data.Cells)
                _resources[cell.GameResourceId] = cell.Count;
        }

        private void SaveInventory()
        {
            foreach (var playerInventoryCell in _data.Cells)
                playerInventoryCell.Count = _resources[playerInventoryCell.GameResourceId];
           
            string json = JsonUtility.ToJson(_data);
            PlayerPrefs.SetString(PREFS_KEY_INVENTORY,json);
        }

        private void SaveCoins() => PlayerPrefs.SetInt(PREFS_KEY_COINS, _coins);
        
        private void LoadCoins() => _coins = PlayerPrefs.GetInt(PREFS_KEY_COINS);
    }
}
