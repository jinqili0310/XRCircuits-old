using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MagicLeap
{

    public class TEMode : MonoBehaviour
    {
        public GameObject InstructorVideo;
        public GameObject SimulationVideo1;
        public GameObject SimulationVideo2;
        public GameObject SimulationVideo3;
        public GameObject Diagram1;
        public GameObject Diagram2;
        public GameObject Diagram3;
        public GameObject BackBtn;
        public GameObject ForwardBtn;

        bool InsIsOn = false;

        private void Start()
        {
            InstructorVideo.SetActive(false);
            InsIsOn = false;
        }

        public void ShowInstructor()
        {
            if(InsIsOn == false)
            {
                InstructorVideo.SetActive(true);
                InsIsOn = true;

                if(SimulationVideo1.activeSelf == true)
                {
                    SimulationVideo1.SetActive(false);
                }else if(SimulationVideo2.activeSelf == true)
                {
                    SimulationVideo2.SetActive(false);
                }else if(SimulationVideo3.activeSelf == true)
                {
                    SimulationVideo3.SetActive(false);
                }
            } 
            else if(InsIsOn == true)
            {
                InstructorVideo.SetActive(false);
                InsIsOn = false;

                if(Diagram1.activeSelf == true)
                {
                    SimulationVideo1.SetActive(true);
                }else if(Diagram2.activeSelf == true)
                {
                    SimulationVideo2.SetActive(true);
                }else if(Diagram3.activeSelf == true)
                {
                    SimulationVideo3.SetActive(true);
                }
            }
            
        }

        public void BackButton()
        {
            if (Diagram1.activeSelf == true)
            {
                BackBtn.SetActive(false);
                ForwardBtn.SetActive(true);
            }
            else if (Diagram2.activeSelf == true)
            {
                Diagram2.SetActive(false);
                SimulationVideo2.SetActive(false);
                Diagram1.SetActive(true);
                SimulationVideo1.SetActive(true);
                BackBtn.SetActive(true);
                ForwardBtn.SetActive(true);
            }
            else if (Diagram3.activeSelf == true)
            {
                Diagram3.SetActive(false);
                SimulationVideo3.SetActive(false);
                Diagram2.SetActive(true);
                SimulationVideo2.SetActive(true);
                BackBtn.SetActive(true);
                ForwardBtn.SetActive(true);
            }
        }

        public void ForwardButton()
        {
            if (Diagram1.activeSelf == true)
            {
                Diagram1.SetActive(false);
                SimulationVideo1.SetActive(false);
                Diagram2.SetActive(true);
                SimulationVideo2.SetActive(true);
                ForwardBtn.SetActive(true);
                BackBtn.SetActive(true);
            }
            else if (Diagram2.activeSelf == true)
            {
                Diagram2.SetActive(false);
                SimulationVideo2.SetActive(false);
                Diagram3.SetActive(true);
                SimulationVideo3.SetActive(true);
                ForwardBtn.SetActive(true);
                BackBtn.SetActive(true);
            }
            else if (Diagram3.activeSelf == true)
            {
                ForwardBtn.SetActive(false);
                BackBtn.SetActive(true);
            }
        }

    }

}