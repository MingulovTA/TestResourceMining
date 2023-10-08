using System;
using System.Linq;
using App.Game.GameResources;
using UnityEngine;

namespace App.Services.PlayerProgress
{
    public class PlayerProgressService : IPlayerProgressService
    {
        private const string PREFS_KEY_COINS = "com.PlayerProgress.Coins";
        private const string PREFS_KEY_INVENTORY = "com.PlayerProgress.Inventory";
        
        private PlayerProgressData _data;
        public PlayerProgressData Data => _data;

        public event Action OnCoinsChanged;
        public event Action OnInventoryChanged;

        public PlayerProgressService()
        {
            _data = new PlayerProgressData();

            if (PlayerPrefs.HasKey(PREFS_KEY_COINS))
            {
                LoadCoins();
                LoadInventory();
            }
            else
            {
                SaveCoins();
                SaveInventory();
            }
        }
        
        public void AddCoins(int coins)
        {
            _data.Coins += coins;
            OnCoinsChanged?.Invoke();
            SaveCoins();
        }
        
        public void SetCoins(int coins)
        {
            _data.Coins = coins;
            OnCoinsChanged?.Invoke();
            SaveCoins();
        }
        
        public void AddResource(GameResourceId resourceId, int count)
        {
            var cell = _data.Inventory.Cells.FirstOrDefault(c => c.GameResourceId == resourceId);
            if (cell == null)
            {
                cell = new PlayerInventoryCell(resourceId, count);
                _data.Inventory.Cells.Add(cell);
            }
            else
            {
                cell.Count += count;
            }
            SaveInventory();
            OnInventoryChanged?.Invoke();
        }

        private void SaveCoins()=>
            PlayerPrefs.SetInt(PREFS_KEY_COINS,_data.Coins);

        private void LoadCoins()=>
            SetCoins(PlayerPrefs.GetInt(PREFS_KEY_COINS));
        
        private void SaveInventory()=>
            PlayerPrefs.SetString(PREFS_KEY_INVENTORY,JsonUtility.ToJson(_data.Inventory));

        private void LoadInventory() =>
            _data.Inventory = JsonUtility.FromJson<Inventory>(PlayerPrefs.GetString(PREFS_KEY_INVENTORY));

        
    }
}
