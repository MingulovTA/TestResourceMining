using System;
using System.Collections.Generic;

namespace App.Services.Game.Config.Marketing
{
    [Serializable]
    public class MarketSettings
    {
        public List<PriceLine> Price = new List<PriceLine>();
    }
}
