using System;
using System.Linq;
using App.Game.GameResources;
using UnityEngine;

namespace App.Scenes.Game
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryCellView _cellPrefab;

        private void Awake()
        {
            foreach (var gameResourceId in Enum.GetValues(typeof(GameResourceId)).Cast<GameResourceId>())
            {
                var icv = Instantiate(_cellPrefab, transform);
                icv.Init(gameResourceId);
            }
            _cellPrefab.gameObject.SetActive(false);
        }
    }
}
