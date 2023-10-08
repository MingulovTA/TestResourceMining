using System;
using App.ServiceLocator.Container;
using UnityEngine;
using UnityEngine.EventSystems;

namespace App.Services.Popups
{
    public class BtnClosePopup : MonoBehaviour, IPointerClickHandler
    {
        private IPopupService _popupService;
        private void Awake()
        {
            _popupService = AppServiceLocator.Resolve<IPopupService>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _popupService.ClosePopup();
        }
    }
}
