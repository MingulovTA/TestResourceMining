using App.Scenes;
using UnityEngine.SceneManagement;

namespace App.Services.Scenes
{
    public class SceneService : ISceneService
    {
        private SceneId _currentScene;
    
        public void LoadScene(SceneId sceneId)
        {
            _currentScene = sceneId;
            SceneManager.LoadScene(sceneId.ToString());
        }

        public SceneId CurrentScene => _currentScene;
    }
}
