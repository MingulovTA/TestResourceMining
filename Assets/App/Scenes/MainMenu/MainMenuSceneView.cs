using App.ServiceLocator.Container;
using App.Services.Popups;
using UnityEngine;

namespace App.Scenes.MainMenu
{
    public class MainMenuSceneView : BaseSceneView
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                AppServiceLocator.Resolve<IPopupService>().Open(PopupId.Forge);
        
            if (Input.GetKeyDown(KeyCode.Alpha2))
                AppServiceLocator.Resolve<IPopupService>().Open(PopupId.Market);
        
            if (Input.GetKeyDown(KeyCode.Alpha3))
                AppServiceLocator.Resolve<IPopupService>().Open(PopupId.Mine);
        
            if (Input.GetKeyDown(KeyCode.Alpha4))
                AppServiceLocator.Resolve<IPopupService>().Open(PopupId.Win);
        }

        protected override void AwakeEntry()
        {
        
        }
    }
}
