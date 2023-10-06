using System.Collections;
using App.ServiceLocator;
using App.ServiceLocator.Container;
using App.ServiceLocator.Interfaces;
using App.Services.Runners;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Scenes.EntryLoading
{
    public class EntryLoadingSceneView : BaseSceneView
    {
        private ICoroutineRunner _coroutineRunner;
        private void Awake()
        {
            IBootStrapperRegistrator bootStrapperRegistrator = new BootStrapperRegistrator();
            AppServiceLocator appServiceLocator = new AppServiceLocator(bootStrapperRegistrator);
            _coroutineRunner = AppServiceLocator.Resolve<ICoroutineRunner>();
        }

        protected override void AwakeEntry()
        {
            _coroutineRunner.Run(FakeLoading());
        }
        
        private IEnumerator FakeLoading()
        {
            yield return null;
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(1);
        }
    }
}
