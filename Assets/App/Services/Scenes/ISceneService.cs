using App.Scenes;
using App.ServiceLocator.Interfaces;

namespace App.Services.Scenes
{
    public interface ISceneService: IService
    {
        void LoadScene(SceneId sceneId);
        SceneId CurrentScene { get; }
    }
}
