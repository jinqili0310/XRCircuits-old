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

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using System.Collections.Generic;

namespace MagicLeap
{
    /// <summary>
    /// This provides an example of interacting with the image tracker visualizers using the controller
    /// </summary>
    [RequireComponent(typeof(PrivilegeRequester))]
    public class ImageTrackingExample : MonoBehaviour
    {
        #region Public Enum
        /* public enum ViewMode : int
        {
            All = 0,
            TrackingCubeOnly,
            DiagramOnly,
            VideoOnly,
            MenuOnly,
            Disabled,
        } */

        public enum ConfigurationStatus : int
        {
            Base = 0,
            Configuration1,
            Configuration2,
            Configuration3,
        }

        public GameObject[] TrackerBehaviours;
        #endregion

        #region Private Variables
        //private ViewMode _viewMode = ViewMode.All;

        private ConfigurationStatus _configurationStatus = ConfigurationStatus.Base;

        [SerializeField, Tooltip("Image Tracking Visualizers to control")]
        private ImageTrackingVisualizer [] _visualizers = null;

        [SerializeField, Tooltip("The Configuration text.")]
        private Text _configurationLabel = null;

        //[SerializeField, Tooltip("The Tracker Status text.")]
        //private Text _trackerStatusLabel = null;

        [Space, SerializeField, Tooltip("ControllerConnectionHandler reference.")]
        private ControllerConnectionHandler _controllerConnectionHandler = null;

        private PrivilegeRequester _privilegeRequester = null;

        private bool _hasStarted = false;
        #endregion

        #region Unity Methods

        // Using Awake so that Privileges is set before PrivilegeRequester Start
        void Awake()
        {
            if (_controllerConnectionHandler == null)
            {
                Debug.LogError("Error: ImageTrackingExample._controllerConnectionHandler is not set, disabling script.");
                enabled = false;
                return;
            }

            // If not listed here, the PrivilegeRequester assumes the request for
            // the privileges needed, CameraCapture in this case, are in the editor.
            _privilegeRequester = GetComponent<PrivilegeRequester>();

            // Before enabling the MLImageTrackerBehavior GameObjects, the scene must wait until the privilege has been granted.
            _privilegeRequester.OnPrivilegesDone += HandlePrivilegesDone;
        }

        /// <summary>
        /// Unregister callbacks and stop input API.
        /// </summary>
        void OnDestroy()
        {
            MLInput.OnControllerButtonDown -= HandleOnButtonDown;
            MLInput.OnTriggerDown -= HandleOnTriggerDown;
            if (_privilegeRequester != null)
            {
                _privilegeRequester.OnPrivilegesDone -= HandlePrivilegesDone;
            }
        }

        /// <summary>
        /// Cannot make the assumption that a privilege is still granted after
        /// returning from pause. Return the application to the state where it
        /// requests privileges needed and clear out the list of already granted
        /// privileges. Also, unregister callbacks.
        /// </summary>
        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                MLInput.OnControllerButtonDown -= HandleOnButtonDown;
                MLInput.OnTriggerDown -= HandleOnTriggerDown;

                //UpdateImageTrackerBehaviours(false);

                //_hasStarted = false;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Enable/Disable the correct objects depending on view options
        /// </summary>
        void UpdateVisualizers()
        {
            foreach (ImageTrackingVisualizer visualizer in _visualizers)
            {
                visualizer.UpdateConfigurationStatus(_configurationStatus);
            }
        }

        /// <summary>
        /// Control when to enable to image trackers based on
        /// if the correct privileges are given.
        /// </summary>
        void UpdateImageTrackerBehaviours(bool enabled)
        {
            foreach (GameObject obj in TrackerBehaviours)
            {
                obj.SetActive(enabled);
            }
        }

        /// <summary>
        /// Once privileges have been granted, enable the camera and callbacks.
        /// </summary>
        void StartCapture()
        {
            if (!_hasStarted)
            {
                UpdateImageTrackerBehaviours(true);

                if (_visualizers.Length < 1)
                {
                    Debug.LogError("Error: ImageTrackingExample._visualizers is not set, disabling script.");
                    enabled = false;
                    return;
                }
                if (_configurationLabel == null)
                {
                    Debug.LogError("Error: ImageTrackingExample._configurationLabel is not set, disabling script.");
                    enabled = false;
                    return;
                }
                //if (_trackerStatusLabel == null)
                //{
                    //Debug.LogError("Error: ImageTrackingExample._trackerStatusLabel is not set, disabling script.");
                    //enabled = false;
                    //return;
                //}

                MLInput.OnControllerButtonDown += HandleOnButtonDown;
                MLInput.OnTriggerDown += HandleOnTriggerDown;

                _hasStarted = true;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Responds to privilege requester result.
        /// </summary>
        /// <param name="result"/>
        void HandlePrivilegesDone(MLResult result)
        {
            if (!result.IsOk)
            {
                if (result.Code == MLResultCode.PrivilegeDenied)
                {
                    Instantiate(Resources.Load("PrivilegeDeniedError"));
                }

                Debug.LogErrorFormat("Error: ImageTrackingExample failed to get requested privileges, disabling script. Reason: {0}", result);
                enabled = false;
                return;
            }

            Debug.Log("Succeeded in requesting all privileges");
            StartCapture();
        }

        /// <summary>
        /// Handles the event for trigger down.
        /// </summary>
        /// <param name="controllerId">The id of the controller.</param>
        /// <param name="triggerValue">The value of the trigger.</param>
        private void HandleOnTriggerDown(byte controllerId, float triggerValue)
        {
            if (_hasStarted && MLImageTracker.IsStarted && _controllerConnectionHandler.IsControllerValid(controllerId))
            {
                if (MLImageTracker.GetTrackerStatus())
                {
                    //MLImageTracker.Disable();
                    //_trackerStatusLabel.text = "Tracker Status: Disabled";
                }
                else
                {
                    MLImageTracker.Enable();
                    //_trackerStatusLabel.text = "Tracker Status: Enabled";
                }
            }
        }

        /// <summary>
        /// Handles the event for button down.
        /// </summary>
        /// <param name="controllerId">The id of the controller.</param>
        /// <param name="button">The button that is being released.</param>
        private void HandleOnButtonDown(byte controllerId, MLInputControllerButton button)
        {
            if (_controllerConnectionHandler.IsControllerValid(controllerId) && button == MLInputControllerButton.Bumper)
            {
                _configurationStatus = (ConfigurationStatus)((int)(_configurationStatus + 1) % Enum.GetNames(typeof(ConfigurationStatus)).Length);
                _configurationLabel.text = string.Format("Configuration Status: {0}", _configurationStatus.ToString());
            }
            UpdateVisualizers();
        }
        #endregion
    }
}
