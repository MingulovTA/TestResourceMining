using App.ServiceLocator.Container;
using App.Services.PlayerProgress;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Scenes.Game
{
    public class CoinsIndicatorView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Text _text;
        private IPlayerInventory _plProgress;
        private void Awake()
        {
            _plProgress = AppServiceLocator.Resolve<IPlayerInventory>();
        }

        private void OnEnable()
        {
            _plProgress.OnCoinsChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable()
        {
            _plProgress.OnCoinsChanged -= UpdateView;
        }

        private void UpdateView()
        {
            _text.text = _plProgress.Coins.ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _plProgress.AddCoins(1);
        }
    }
}
