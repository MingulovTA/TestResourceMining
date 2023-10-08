using App.Scenes;
using App.ServiceLocator;
using App.ServiceLocator.Container;
using App.ServiceLocator.Interfaces;
using App.Services.Scenes;
using UnityEngine;

namespace App
{
    public class AppEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            if (AppServiceLocator.IsInited) return;
            InitServiceLocator();
            GotoMasterScene();
        }

        private void InitServiceLocator()
        {
            IBootStrapperRegistrator bootStrapperRegistrator = new BootStrapperRegistrator();
            AppServiceLocator appServiceLocator = new AppServiceLocator(bootStrapperRegistrator);
        }

        private void GotoMasterScene()
        {
            AppServiceLocator.Resolve<ISceneService>().LoadScene(SceneId.EntryLoading);
        }
    }
}
