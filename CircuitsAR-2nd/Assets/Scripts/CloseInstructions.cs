using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MagicLeap
{

    public class CloseInstructions : MonoBehaviour
    {
        public GameObject InstructionFrame;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void CloseTheFrame()
        {
            InstructionFrame.SetActive(false);
        }

        public void QuestionMark()
        {
            if(InstructionFrame.activeSelf == true)
            {
                InstructionFrame.SetActive(false);
            }
            else if(InstructionFrame.activeSelf == false)
            {
                InstructionFrame.SetActive(true);
            }
            
        }
    }

}
