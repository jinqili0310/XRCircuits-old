using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

namespace MagicLeap
{
    public class MenuController : MonoBehaviour
    {
        private bool isOn = false;
        public GameObject Menu;

        void Start()
        {

        }

        public void ShowMenu()
        {
            if (isOn == false)
            {
                Menu.SetActive(true);
                isOn = true;
            }
            else if (isOn == true)
            {
                Menu.SetActive(false);
                isOn = false;
            }

            

        }


    }


}