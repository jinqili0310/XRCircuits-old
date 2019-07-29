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

namespace MagicLeap
{
    /// <summary>
    /// This class handles visibility on image tracking, displaying and hiding prefabs
    /// when images are detected or lost.
    /// </summary>
    [RequireComponent(typeof(MLImageTrackerBehavior))]
    public class ImageTrackingVisualizer : MonoBehaviour
    {
        #region Private Variables
        private MLImageTrackerBehavior _trackerBehavior = null;
        private bool _targetFound = false;

        [SerializeField, Tooltip("Text to update on ImageTracking changes.")]
        private Text _statusLabel = null;
        // Stores initial text
        private string _prefix;
        private string _eventString;

        [SerializeField, Tooltip("Game Object showing the tracking cube")]
        private GameObject _trackingCube = null;
        [SerializeField, Tooltip("Game Object showing the diagram")]
        private GameObject _diagramBase = null;
        [SerializeField, Tooltip("Game Object showing the diagram")]
        private GameObject _diagramConf1 = null;
        [SerializeField, Tooltip("Game Object showing the diagram")]
        private GameObject _diagramConf2 = null;
        [SerializeField, Tooltip("Game Object showing the diagram")]
        private GameObject _diagramConf3 = null;
        [SerializeField, Tooltip("Game Object showing the video base")]
        public GameObject _videoBase = null;
        [SerializeField, Tooltip("Game Object showing the video conf1")]
        public GameObject _videoConf1 = null;
        [SerializeField, Tooltip("Game Object showing the video conf2")]
        public GameObject _videoConf2 = null;
        [SerializeField, Tooltip("Game Object showing the video conf3")]
        public GameObject _videoConf3 = null;
        [SerializeField, Tooltip("Game Object showing the menu")]
        public GameObject _menu = null;

        private ImageTrackingExample.ConfigurationStatus _lastConfiguration = ImageTrackingExample.ConfigurationStatus.Base;
        #endregion

        #region Unity Methods
        /// <summary>
        /// Validate inspector variables
        /// </summary>
        void Awake()
        {
            if (null == _trackingCube)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._trackingCube is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _diagramBase)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._diagram is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _diagramConf1)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._diagram is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _diagramConf2)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._diagram is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _diagramConf3)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._diagram is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _videoBase)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._videoBase is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _videoConf1)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._videoConf1 is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _videoConf2)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._videoConf2 is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _videoConf3)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._videoConf3 is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _menu)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._menu is not set, disabling script.");
                enabled = false;
                return;
            }
            if (null == _statusLabel)
            {
                Debug.LogError("Error: ImageTrackingVisualizer._statusLabel is not set, disabling script.");
                enabled = false;
                return;
            }
        }

        /// <summary>
        /// Initializes variables and register callbacks
        /// </summary>
        void Start()
        {
            _prefix = _statusLabel.text;
            _statusLabel.text = _prefix + "Target Lost";
            _eventString = "";
            _trackerBehavior = GetComponent<MLImageTrackerBehavior>();
            _trackerBehavior.OnTargetFound += OnTargetFound;
            _trackerBehavior.OnTargetLost += OnTargetLost;

            RefreshConfiguration();
        }

        private void Update()
        {
            _statusLabel.text = String.Format("{0}[{1}/{2}] {3}", _prefix, _trackerBehavior.IsTracking, _trackerBehavior.TrackingStatus, _eventString);
        }

        /// <summary>
        /// Unregister calbacks
        /// </summary>
        void OnDestroy()
        {
            _trackerBehavior.OnTargetFound -= OnTargetFound;
            _trackerBehavior.OnTargetLost -= OnTargetLost;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Update which objects should be visible
        /// </summary>
        /// <param name="configurationStatus">Contains the mode to view</param>
        public void UpdateConfigurationStatus(ImageTrackingExample.ConfigurationStatus configurationStatus)
        {
            _lastConfiguration = configurationStatus;
            RefreshConfiguration();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// De/Activate objects to be hidden/seen
        /// </summary>
        private void RefreshConfiguration()
        {
            switch (_lastConfiguration)
            {
                case ImageTrackingExample.ConfigurationStatus.Base:
                    _trackingCube.SetActive(_targetFound);
                    _diagramBase.SetActive(_targetFound);
                    _diagramConf1.SetActive(false);
                    _diagramConf2.SetActive(false);
                    _diagramConf3.SetActive(false);
                    _menu.SetActive(_targetFound);
                    _videoBase.SetActive(_targetFound);
                    _videoConf1.SetActive(false);
                    _videoConf2.SetActive(false);
                    _videoConf3.SetActive(false);
                    break;
                case ImageTrackingExample.ConfigurationStatus.Configuration1:
                    _trackingCube.SetActive(_targetFound);
                    _diagramBase.SetActive(false);
                    _diagramConf1.SetActive(_targetFound);
                    _diagramConf2.SetActive(false);
                    _diagramConf3.SetActive(false);
                    _menu.SetActive(_targetFound);
                    _videoBase.SetActive(false);
                    _videoConf1.SetActive(_targetFound);
                    _videoConf2.SetActive(false);
                    _videoConf3.SetActive(false);
                    break;
                case ImageTrackingExample.ConfigurationStatus.Configuration2:
                    _trackingCube.SetActive(_targetFound);
                    _diagramBase.SetActive(false);
                    _diagramConf1.SetActive(false);
                    _diagramConf2.SetActive(_targetFound);
                    _diagramConf3.SetActive(false);
                    _menu.SetActive(_targetFound);
                    _videoBase.SetActive(false);
                    _videoConf1.SetActive(false);
                    _videoConf2.SetActive(_targetFound);
                    _videoConf3.SetActive(false);
                    break;
                case ImageTrackingExample.ConfigurationStatus.Configuration3:
                    _trackingCube.SetActive(_targetFound);
                    _diagramBase.SetActive(false);
                    _diagramConf1.SetActive(false);
                    _diagramConf2.SetActive(false);
                    _diagramConf3.SetActive(_targetFound);
                    _menu.SetActive(_targetFound);
                    _videoBase.SetActive(false);
                    _videoConf1.SetActive(false);
                    _videoConf2.SetActive(false);
                    _videoConf3.SetActive(_targetFound);
                    break;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Callback for when tracked image is found
        /// </summary>
        /// <param name="isReliable"> Contains if image found is reliable </param>
        private void OnTargetFound(bool isReliable)
        {
            _eventString = String.Format("Target Found ({0})", (isReliable ? "Reliable" : "Unreliable"));
            _targetFound = true;
            RefreshConfiguration();
        }

        /// <summary>
        /// Callback for when image tracked is lost
        /// </summary>
        private void OnTargetLost()
        {
            _eventString = "Target Lost";
            //_targetFound = false;
            //RefreshConfiguration();
        }
        #endregion
    }
}
