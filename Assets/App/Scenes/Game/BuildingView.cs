using System;
using System.Collections.Generic;
using System.Linq;
using App.ServiceLocator.Container;
using App.Services.Game;
using App.Services.Game.Buildings;
using App.Services.Game.Enums.Buildings;
using App.Services.Popups;
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

        private IGameService _gameService;
        private IPopupService _popupService;
        private IBuilding _building;

        private Dictionary<BuildingTypeId, PopupId> _popupsForBuildings = new Dictionary<BuildingTypeId, PopupId>
        {
            {BuildingTypeId.Forge, PopupId.Forge},
            {BuildingTypeId.Market, PopupId.Market},
            {BuildingTypeId.Mine, PopupId.Mine}
        };
        public void Init()
        {
            _gameService = AppServiceLocator.Resolve<IGameService>();
            _popupService = AppServiceLocator.Resolve<IPopupService>();
            _building = _gameService.GameData.Buildings[_buildingTypeId].FirstOrDefault(b => b.IndexId == _indexId);
            if (_building == null)
                gameObject.SetActive(false);
        }

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
            _gameService.GameData.SelectedBuildingIndex = _indexId;
            _popupService.Open(_popupsForBuildings[_buildingTypeId]);
        }
    }
}
