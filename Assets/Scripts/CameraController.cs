using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


namespace DontWannaDie
{
    public class CameraController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Vector3 _cameraInitialOffset;
        [SerializeField] private GameObject _target;

        private float _cameraXZOffset;
        private Vector3 _cameraRotationOffset;

        #endregion


        #region UnityMethods

        private void Start()
        {
            transform.position = _cameraInitialOffset;
            _cameraXZOffset = Mathf.Sqrt(Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.z, 2));
        }

        private void FixedUpdate()
        {
            transform.position = NewCameraCoords(_target);
            transform.rotation = _target.transform.rotation;
            transform.Rotate(45, 0, 0, Space.Self);
        }

        #endregion


        #region Methods
        
        private Vector3 NewCameraCoords(GameObject target)
        {
            _cameraRotationOffset.x = - _cameraXZOffset * Mathf.Sin(_target.transform.rotation.eulerAngles.y * Mathf.PI / 180);
            _cameraRotationOffset.y = _cameraInitialOffset.y;
            _cameraRotationOffset.z = - _cameraXZOffset * Mathf.Cos(_target.transform.rotation.eulerAngles.y * Mathf.PI / 180);
            return _cameraRotationOffset + _target.transform.position;
        }

        #endregion
    }
}

