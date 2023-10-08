using System;
using System.Collections.Generic;

namespace App.Services.PlayerProgress
{
    [Serializable]
    public class PlayerInventoryData
    {
        public List<PlayerInventoryCell> Cells = new List<PlayerInventoryCell>();
    }
}
