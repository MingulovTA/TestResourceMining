using System;
using System.Collections.Generic;
using App.Services.Game.Config.Forging;

namespace App.Services.Game.Config
{
    [Serializable]
    public class ForgeSettings
    {
        public float ForgeTime;
        public List<Forge> Forges = new List<Forge>();
    }
}
