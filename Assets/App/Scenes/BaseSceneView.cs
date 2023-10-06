using App.ServiceLocator.Container;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace App.Scenes
{
    public abstract class BaseSceneView : MonoBehaviour
    {
        private void Start()
        {
            if (!AppServiceLocator.IsInited)
                SceneManager.LoadScene(0);
            else
                AwakeEntry();
        }

        protected  abstract void AwakeEntry();
    }
}