using System;
using App.ServiceLocator.Interfaces;

namespace App.Services.Popups
{
    public interface IPopupService : IService
    {
        void Open(PopupId popupId, Action<PopupCloseResult> closeCallback = null);

        T Open<T>(PopupId popupId, Action<PopupCloseResult> closeCallback = null) where T : class;
        void ClosePopup();
    }
}
