using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

namespace MagicLeap
{
    public class QuestionController : MonoBehaviour
    {

        private bool isOn = false;
        public GameObject Question;

        void Start()
        {
        
        }

        public void ShowInstruction()
        {

            if(isOn == false)
            {
                Question.SetActive(true);
                isOn = true;
            }
            else if(isOn == true)
            {
                Question.SetActive(false);
                isOn = false;
            }

            Debug.Log(Question.activeSelf.ToString());
        }


    }


}