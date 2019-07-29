// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
//
// Copyright (c) 2019 Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Creator Agreement, located
// here: https://id.magicleap.com/creator-terms
//
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

using System.Collections;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

namespace MagicLeap
{
    /// <summary>
    /// This class handles setting the position and rotation of the
    /// transform to match the camera's based on input distance and height
    /// </summary>
    /// 
    [RequireComponent(typeof(ControllerConnectionHandler))]
    public class PlaceFromCamera : MonoBehaviour
    {
        //private bool isOn = false;

        public enum LookDirection
        {
            None = 0,
            LookAtCamera = 1,
            LookAwayFromCamera = 2
        }

        #region Private Variables
        [SerializeField] private ControllerConnectionHandler _controllerConnectionHandler = null;

        [SerializeField, Tooltip("The distance from the camera through its forward vector.")]
        private float _distance = 0.0f;

        [SerializeField, Tooltip("The distance on the local Y axis from the camera's forward ray.")]
        private float _heightOffset = 0.0f;

        [SerializeField, Tooltip("The distance on the local X axis from the camera's forward ray.")]
        private float _lateralOffset = 0.0f;

        [SerializeField, Tooltip("The approximate time it will take to reach the current position.")]
        private float _positionSmoothTime = 5f;
        private Vector3 _positionVelocity = Vector3.zero;

        [SerializeField, Tooltip("The approximate time it will take to reach the current rotation.")]
        private float _rotationSmoothTime = 5f;

        [SerializeField, Tooltip("The direction the transform should face.")]
        private LookDirection _lookDirection = LookDirection.LookAwayFromCamera;

        public bool _placeOnAwake = true;

        public bool _placeOnUpdate = false;


        // MobileApp-specific variables
        private bool _isCalibrated = false;
        private Quaternion _calibrationOrientation = Quaternion.identity;
        private const float MOBILEAPP_FORWARD_DISTANCE_FROM_CAMERA = 0.75f;
        private const float MOBILEAPP_UP_DISTANCE_FROM_CAMERA = -0.1f;

        #endregion

        #region Public Properties
        /// <summary>
        /// When enabled automatic placement will occur on each Update cycle.
        /// </summary>
        public bool PlaceOnUpdate
        {
            get { return _placeOnUpdate; }
            set { _placeOnUpdate = value; }
        }

        #endregion

        #region Unity Methods
        /// <summary>
        /// Set the transform from latest position if flag is checked.
        /// </summary>
        /// 

        void Start()
        {
            MLInput.OnControllerButtonUp += HandleOnButtonUp;

            UpdateTransform(Camera.main);

        }

        void Awake()
        {
            if (_placeOnAwake)
            {
                StartCoroutine(UpdateTransformEndOfFrame());
            }
        }

        void Update()
        {
            Camera mainCamera = Camera.main;

            if (_placeOnUpdate && mainCamera.transform.hasChanged)
            {
                UpdateTransform(mainCamera);
            }

            //isOn = false;
        }

        private void HandleOnButtonUp(byte controllerId, MLInputControllerButton button)
        {
            MLInputController controller = _controllerConnectionHandler.ConnectedController;

            if (_controllerConnectionHandler.ConnectedController.Id == controllerId && button == MLInputControllerButton.HomeTap)
            {
                /*if(_placeOnUpdate == false && isOn == false)
                {
                    _placeOnUpdate = true;
                    isOn = true;
                    Debug.Log(_placeOnUpdate.ToString());
                }
                else if(_placeOnUpdate == true && isOn == true)
                {
                    _placeOnUpdate = false;
                    isOn = false;
                }*/

                UpdateTransform(Camera.main);
                
            }

            }

        void OnValidate()
        {
            _positionSmoothTime = Mathf.Max(0.01f, _positionSmoothTime);
            _rotationSmoothTime = Mathf.Max(0.01f, _rotationSmoothTime);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Reset position and rotation to match current camera values, after the end of frame.
        /// </summary>
        private IEnumerator UpdateTransformEndOfFrame()
        {
            // Wait until the camera has finished the current frame.
            yield return new WaitForEndOfFrame();

            UpdateTransform(Camera.main);
        }

        /// <summary>
        /// Reset position and rotation to match current camera values.
        /// </summary>
        private void UpdateTransform(Camera camera)
        {
            // Move the object in front of the camera with specified offsets.
            Vector3 offsetVector = (camera.transform.up * _heightOffset) + (camera.transform.right * _lateralOffset);
            Vector3 targetPosition = camera.transform.position + offsetVector + (camera.transform.forward * _distance);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _positionVelocity, _positionSmoothTime);

            Quaternion targetRotation = transform.rotation;

            // Rotate the object to face the camera.
            if (_lookDirection == LookDirection.LookAwayFromCamera)
            {
                targetRotation = Quaternion.LookRotation(transform.position - camera.transform.position, camera.transform.up);
            }
            else if (_lookDirection == LookDirection.LookAtCamera)
            {
                targetRotation = Quaternion.LookRotation(camera.transform.position - transform.position, camera.transform.up);
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime / _rotationSmoothTime);

            if (_placeOnAwake)
            {
                // Snap to the location right away.
                transform.position = targetPosition;
                transform.rotation = targetRotation;

                _placeOnAwake = false;
            }
        }
        #endregion
    }
}
