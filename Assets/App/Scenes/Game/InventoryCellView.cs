using App.Game.GameResources;
using App.ServiceLocator.Container;
using App.Services.PlayerProgress;
using UnityEngine;
using UnityEngine.UI;

namespace App.Scenes.Game
{
    public class InventoryCellView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private GameResourceId _gameResourceId;
        
        private IPlayerInventory _playerInventory;

        private void Awake()
        {
            _playerInventory = AppServiceLocator.Resolve<IPlayerInventory>();
        }

        public void Init(GameResourceId gameResourceId)
        {
            _gameResourceId = gameResourceId;
            var icon = Resources.Load($"ResIcons/{_gameResourceId}");
            icon = Instantiate(icon,transform);
            _playerInventory.OnInventoryChanged += InventoryUpdatedHandler;
            UpdateView();
        }

        private void OnDestroy()
        {
            _playerInventory.OnInventoryChanged -= InventoryUpdatedHandler;
        }

        private void InventoryUpdatedHandler(GameResourceId gameResourceId)
        {
            if (_gameResourceId!=gameResourceId) return;
            UpdateView();
        }

        private void UpdateView()
        {
            int count = _playerInventory.GetResourceCount(_gameResourceId);
            if (count > 0)
            {
                _text.text = count.ToString();
                if (!gameObject.activeSelf)
                    Enable();
            }
            else
            {
                Disable();
            }
        }

        private void Enable()
        {
            gameObject.SetActive(true);
        }

        private void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}
