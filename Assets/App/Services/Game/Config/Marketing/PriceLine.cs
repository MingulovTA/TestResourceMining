using System;
using App.Game.GameResources;

namespace App.Services.Game.Config.Marketing
{
    [Serializable]
    public class PriceLine
    {
        public GameResourceId GameResourceId;
        public int Price;
    }
}
