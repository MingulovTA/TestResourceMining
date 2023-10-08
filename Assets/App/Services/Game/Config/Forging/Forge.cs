using System;
using System.Collections.Generic;
using App.Game.GameResources;

namespace App.Services.Game.Config.Forging
{
    [Serializable]
    public class Forge
    {
        public List<GameResourceId> Prescription = new List<GameResourceId>();
        public GameResourceId Result;
    }
}
