using System;
using UnityEngine;

namespace App.Services.Popups
{
    public abstract class BasePopup : MonoBehaviour
    {
        private Action<PopupCloseResult> _closeCallback;
    
        public void Open(Action<PopupCloseResult> closeCallback)
        {
            _closeCallback = closeCallback;
            gameObject.SetActive(true);
        }
    
        public void Close(PopupCloseResult result = PopupCloseResult.Cancel)
        {
            _closeCallback?.Invoke(result);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Close();
        }
    }
}