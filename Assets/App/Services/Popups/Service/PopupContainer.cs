using UnityEngine;

namespace App.Services.Popups
{
    public class PopupContainer : MonoBehaviour
    {
        public const string POPUPS_CONTAINER_RESOURCE_PATH = "Popups/_PopupsContainer";
        
        [SerializeField] private Transform _wp;

        public Transform Wp => _wp;
    }
}
