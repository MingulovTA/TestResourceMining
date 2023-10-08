using System.Collections.Generic;
using UnityEngine;

namespace App.Scenes.Game
{
    public class GameSceneView : BaseSceneView
    {
        [SerializeField] private List<BuildingView> _buildingViews;
        protected override void Construct()
        {
            foreach (var buildingView in _buildingViews)
                buildingView.Init();
        }

        public void BtnAbortGameClick()
        {
            _gameService.AbortGame();
        }
    }
}