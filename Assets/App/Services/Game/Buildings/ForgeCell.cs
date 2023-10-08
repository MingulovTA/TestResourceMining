using System;
using System.Linq;
using App.Game.GameResources;

namespace App.Services.Game.Buildings
{
    public class ForgeCell
    {
        private static readonly GameResourceId[] allResources = Enum.GetValues(typeof(GameResourceId)).Cast<GameResourceId>().ToArray();
        
        private GameResourceId _gameResourceId;
        private int _index;
        
        public GameResourceId GameResourceId => _gameResourceId;

        public void Select()
        {
            _index++;
            if (_index >= allResources.Length)
                _index = 0;
            _gameResourceId = allResources[_index];
        }
    }
}
