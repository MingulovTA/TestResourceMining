using UnityEngine;

namespace App.Services.Game.Config
{
    [CreateAssetMenu(fileName = "New GameConfig", menuName = "GameConfig")]
    public class GameConfigScriptableObject : ScriptableObject
    {
        public GameConfig GameConfig;
    }
}
