using System;
using App.ServiceLocator.Interfaces;

namespace App.Services.Popups
{
    public interface IPopupService : IService
    {
        bool IsAnyPopupOpened { get; }
        void Open(PopupId popupId, Action<PopupCloseResult> closeCallback = null);

        T Open<T>(PopupId popupId, Action<PopupCloseResult> closeCallback = null) where T : class;
        void ClosePopup();
    }
}
