using App.Services.Game;
using UnityEngine;

namespace App.Scenes.Game
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventoryCellView _cellPrefab;

        private void Awake()
        {
            foreach (var gameResourceId in GameConsts.AllResources)
            {
                var icv = Instantiate(_cellPrefab, transform);
                icv.Init(gameResourceId);
            }
            _cellPrefab.gameObject.SetActive(false);
        }
    }
}
