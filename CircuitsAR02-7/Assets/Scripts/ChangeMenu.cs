using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

namespace MagicLeap
{
    public class ChangeMenu : MonoBehaviour
    {

        public GameObject CurrentButton;
        public GameObject CurrentValues;

        public GameObject ResistanceButton;
        public GameObject ResistanceValues;


        void Start()
        {
            //CurrentButton = GameObject.Find("CurrentButton");
            //CurrentValues = GameObject.Find("CurrentValues").GetComponent<GameObject>();

            //ResistanceButton = GameObject.Find("ResistanceButton");
            //ResistanceValues = GameObject.Find("ResistanceValues").GetComponent<GameObject>();

        }

        public void ChangeCurrent()
        {
            CurrentValues.SetActive(true);
            
        }

        public void ChangeResistance()
        {
            ResistanceValues.SetActive(true);

        }

        public void ChangeCurrentValue()
        {

            CurrentValues.SetActive(false);
        }

        public void ChangeResistanceValue()
        {
            ResistanceValues.SetActive(false);
        }


    }
    

}
