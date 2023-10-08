using System;

namespace App.Services.PlayerProgress
{
    [Serializable]
    public class PlayerProgressData
    {
        public Inventory Inventory = new Inventory();
        public int Coins;
    }
}
