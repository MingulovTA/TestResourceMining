using System;
using System.Collections.Generic;
using System.Linq;
using App.Services.Game.Enums.GameResources;

namespace App.Services.Game
{
    public class GameConsts
    {
        public static readonly List<GameResourceId> AllResources =
            Enum.GetValues(typeof(GameResourceId)).Cast<GameResourceId>().ToList();
        
        
    }
}
