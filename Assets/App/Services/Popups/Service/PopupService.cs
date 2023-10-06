using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace App.Services.Popups
{
    public class PopupService : IPopupService
    {
        private const string POPUPS_RESOURCE_PATH = "Popups/";

        private PopupContainer _popupContainer;
        private Dictionary<BasePopup,Action<PopupCloseResult>> _popupsQueue = new Dictionary<BasePopup, Action<PopupCloseResult>>();

        public Action<PopupId> OnPopupOpened;

        public PopupService(PopupContainer popupContainer)
        {
            _popupContainer = popupContainer;
            DisableContainerIfNeed();
        }

        public void Open(PopupId popupId, Action<PopupCloseResult> closeCallback = null)
        {
            Open<BasePopup>(popupId,closeCallback);
        }

        public T Open<T>(PopupId popupId, Action<PopupCloseResult> closeCallback = null) where T : class
        {
            BasePopup basePopupPrefab = Resources.Load<BasePopup>($"{POPUPS_RESOURCE_PATH}{popupId}");
            if (basePopupPrefab == null)
            {
                Debug.LogError($"PopupService Attention! Popup {popupId} not found. Abort...");
                return null;
            }

            BasePopup basePopup = Object.Instantiate(basePopupPrefab, _popupContainer.Wp);
            
            _popupsQueue.Add(basePopup,closeCallback);
            basePopup.Open(PopupCloseHandler);
            EnableContainer();
            OnPopupOpened?.Invoke(popupId);
            return basePopup as T;
        }
        
        private void PopupCloseHandler(PopupCloseResult closeResult)
        {
            Object.Destroy(_popupsQueue.Last().Key.gameObject);
            var externalCallback = _popupsQueue.Last().Value;
            _popupsQueue.Remove(_popupsQueue.Last().Key);
            DisableContainerIfNeed();
            externalCallback?.Invoke(closeResult);
        }

        private void DisableContainerIfNeed()
        {
            if (_popupsQueue.Count==0)
                _popupContainer.gameObject.SetActive(false);
        }

        private void EnableContainer()
        {
            _popupContainer.gameObject.SetActive(true);
        }
    }
}