using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scenes.MainMenu
{
    public class RadioButtonView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RadioGroupView _radioGroupView;
        [SerializeField] private GameObject _selected;
        [SerializeField] private int _itemIndex;

        private void OnEnable()
        {
            _radioGroupView.OnItemIndexChanged += UpdateView;
            UpdateView();
        }

        private void OnDisable()
        {
            _radioGroupView.OnItemIndexChanged -= UpdateView;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _radioGroupView.Select(_itemIndex);
        }

        private void UpdateView()
        {
            _selected.gameObject.SetActive(_radioGroupView.CurrentItemIndex==_itemIndex);
        }
    }
}
