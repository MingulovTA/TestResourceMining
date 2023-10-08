using System.Collections;
using App.ServiceLocator.Container;
using App.Services.Game;
using App.Services.Scenes;
using UnityEngine;

namespace App.Scenes.EntryLoading
{
    public class EntryLoadingSceneView : BaseSceneView
    {
        private ISceneService _sceneService;
        
        protected override void Construct()
        {
            _sceneService = AppServiceLocator.Resolve<ISceneService>();
            StartCoroutine(FakeLoading());
        }
        
        private IEnumerator FakeLoading()
        {
            yield return new WaitForSeconds(0.5f);
            _gameService.LoadMainMenu();
        }
    }
}
