using App.Game.Buildings;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Scenes.Game
{
    public class BuildingView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private readonly Color _focusColor = new Color(0.95f,0.95f,0.95f,0.95f);
        private readonly Color _defaultColor = new Color(1,1,1,1);

        [SerializeField] private BuildingTypeId _buildingTypeId;
        [SerializeField] private int _indexId;
        [SerializeField] private SpriteRenderer _spr;
    
        public void OnPointerEnter(PointerEventData eventData)
        {
            _spr.color = _focusColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _spr.color = _defaultColor;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _spr.color = _defaultColor;
            OpenPopup();
        }

        private void OpenPopup()
        {
        
        }
    }
}
