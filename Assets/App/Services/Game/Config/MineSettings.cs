using System;
using System.Collections.Generic;
using App.Services.Game.Enums.GameResources;

namespace App.Services.Game.Config
{
    [Serializable]
    public class MineSettings
    {
        public float MineTime;
        public List<GameResourceId> GameResourceIds = new List<GameResourceId>();
    }
}
