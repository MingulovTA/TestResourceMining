using App.Services.Game.Enums.GameResources;

namespace App.Services.Game.Buildings
{
    public class ForgeCell
    {
        private GameResourceId _gameResourceId;
        private int _index;
        
        public GameResourceId GameResourceId => _gameResourceId;

        public void Select()
        {
            _index++;
            if (_index >= GameConsts.AllResources.Count)
                _index = 0;
            _gameResourceId = GameConsts.AllResources[_index];
        }
    }
}
