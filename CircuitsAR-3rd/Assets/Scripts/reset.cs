using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


namespace MagicLeap
{
    public class reset : MonoBehaviour
    {
        public ImageTrackingVisualizer other;

        public void Reset()
        {
            
            other._videoBase.SetActive(true);
            other._videoConf1.SetActive(false);
            other._videoConf2.SetActive(false);
            other._videoConf3.SetActive(false);
        }
    }
}

