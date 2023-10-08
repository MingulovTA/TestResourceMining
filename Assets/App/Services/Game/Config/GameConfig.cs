using System;
using System.Collections.Generic;
using App.Services.Game.Config.Marketing;

namespace App.Services.Game.Config
{
    [Serializable]
    public class GameConfig
    {
        public int CoinsForWin;
        public List<MineSettings> Mines = new List<MineSettings>();
        public List<ForgeSettings> Forges = new List<ForgeSettings>();
        public List<MarketSettings> Markets = new List<MarketSettings>();
    }
}
