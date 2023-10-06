using UnityEngine;

namespace App.Environment
{
    public class RotatingItem : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotatingVector = new Vector3(0,0,1);
        
        private Transform _transform;
        private Vector3 _angle;

        private void Awake()
        {
            _transform = transform;
            _angle = _transform.localEulerAngles;
        }
        
        private void Update()
        {
            _angle+=_rotatingVector*Time.deltaTime;
            _transform.localEulerAngles = _angle;
        }
    }
}
