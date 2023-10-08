using System;
using App.Services.Game.Enums.GameResources;

namespace App.Services.Game.Config.Marketing
{
    [Serializable]
    public class PriceLine
    {
        public GameResourceId GameResourceId;
        public int Price;
    }
}
