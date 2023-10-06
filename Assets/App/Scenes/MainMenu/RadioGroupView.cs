using System;
using UnityEngine;

namespace App.Scenes.MainMenu
{
    public class RadioGroupView : MonoBehaviour
    {
        [SerializeField] private int _currentItemIndex;

        public int CurrentItemIndex => _currentItemIndex;

        public event Action OnItemIndexChanged;
    
        public void Select(int itemIndex)
        {
            if (_currentItemIndex==itemIndex) return;
            _currentItemIndex = itemIndex;
            OnItemIndexChanged?.Invoke();
        }
    }
}
