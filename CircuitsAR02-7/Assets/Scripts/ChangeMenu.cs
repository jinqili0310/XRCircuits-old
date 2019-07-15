using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;

namespace MagicLeap
{
    public class ChangeMenu : MonoBehaviour
    {
        /*private MLInputController _controller;
        private const float _rotationSpeed = 30.0f;
        private const float _distance = 2.0f;
        private const float _moveSpeed = 1.2f;
        private bool _enabled = false;
        private bool _bumper = false;

        public ControllerConnectionHandler _controllerConnectionHandler ;


        MLInputController controller = _controllerConnectionHandler.ConnectedController;

        float _lastY;

        private MLInputController _controller;
        private bool _enabled = false;
        float _lastY;*/

        public TouchpadGestures other;

        public GameObject VoltageButton;
        public GameObject VoltageValues;
        public GameObject VoltageValue1;
        public GameObject VoltageValue2;
        public GameObject VoltageValue3;

        /*public enum VoltageMenu : int
        {
            Voltage0 = 0,
            Voltage1,
            Voltage2,
            Voltage3,
        }*/

        void Start()
        {
            VoltageButton = GameObject.Find("VoltageButton");
            VoltageValues = GameObject.Find("VoltageValues").GetComponent<GameObject>();
            //VoltageValue1 = GameObject.Find("VoltageValue1");
            //VoltageValue2 = GameObject.Find("VoltageValue2");
            //VoltageValue3 = GameObject.Find("VoltageValue3");

            //MLInput.Start();
            //_controller = MLInput.GetController(MLInput.Hand.Left);
        }

        public void ChangeVoltage()
        {
            //VoltageButton.SetActive(true);
            VoltageValues.SetActive(true);
            Debug.Log("voltagevalues is " + VoltageValues.activeSelf.ToString());
            //VoltageValue1.SetActive(true);
            //VoltageValue2.SetActive(true);
            //VoltageValue3.SetActive(true);
            

            /*float v2X = voltage2.transform.position.x;
            float v2Y = voltage2.transform.position.y;
            float v2Z = voltage2.transform.position.z;*/

            //bug.Log("voltage1 is: " + voltage1.activeSelf.ToString());
            //bug.Log("voltage3 is: " + voltage3.activeSelf.ToString());
            //ltage3.SetActive(false);
            //ChangeVoltageValue();
        }

        public void ChangeValue1()
        {
            VoltageValues.SetActive(false);
            /*VoltageValue1.SetActive(false);
            VoltageValue2.SetActive(false);
            VoltageValue3.SetActive(false);*/
        }


        /*void Awake()
        {
            voltage0 = GameObject.Find("voltage0");
            voltage1 = GameObject.Find("voltage1");
            voltage2 = GameObject.Find("voltage2");
            voltage3 = GameObject.Find("voltage3");

            MLInput.Start();
            _controller = MLInput.GetController(MLInput.Hand.Left);

            if (_controllerConnectionHandler == null)
            {
                Debug.LogError("Error: ImageTrackingExample._controllerConnectionHandler is not set, disabling script.");
                enabled = false;
                return;
            }

        }*/


        //public void ChangeVoltageValue()
        //{
            /*switch (bool)
            {
                case other.NumUp.boolIsTrue:

                    voltage0.SetActive(false);
                    voltage1.SetActive(true);
                    voltage2.SetActive(false);
                    voltage3.SetActive(false);
                    Debug.Log("voltage2-up is: " + voltage2.activeSelf.ToString());
                    Debug.Log("voltage1-up is: " + voltage1.activeSelf.ToString());
                    Debug.Log("voltage3-up is: " + voltage3.activeSelf.ToString());
                    break;

                case bool other.NumUp == false:

                    voltage0.SetActive(false);
                    voltage1.SetActive(false);
                    voltage2.SetActive(false);
                    voltage3.SetActive(true);
                    Debug.Log("voltage2-down is: " + voltage2.activeSelf.ToString());
                    Debug.Log("voltage1-down is: " + voltage1.activeSelf.ToString());
                    Debug.Log("voltage3-down is: " + voltage3.activeSelf.ToString());
                    break;
            }*/



            /*if (_controller.Touch1PosAndForce.z > 0.0f && _enabled)
            {
                //float _lastX = _controller.Touch1PosAndForce.x;
                float _lastY = _controller.Touch1PosAndForce.y;
            }

            /*if (!_controllerConnectionHandler.IsControllerValid())
            {
                return;
            }*/


            /*if (_controller.Touch1Active)
            {
                if (_controller.TouchpadGesture.Type == MLInputControllerTouchpadGestureType.Swipe)
                {
                    if (_controller.Touch1PosAndForce.y - _lastY < -0.001)
                    {
                        //decrease the number
                        float v2X = voltage2.transform.position.x;
                        float v2Y = voltage2.transform.position.y;
                        float v2Z = voltage2.transform.position.z;

                        double addNum = 0.04;
                        float addNumber = System.Convert.ToSingle(addNum);

                        voltage2.transform.position = new Vector3(v2X, v2Y - addNumber, v2Z);
                    }
                    else if (_controller.Touch1PosAndForce.y - _lastY > 0.001)
                    {
                        //increase the number
                        float v2X = voltage2.transform.position.x;
                        float v2Y = voltage2.transform.position.y;
                        float v2Z = voltage2.transform.position.z;

                        double addNum = 0.04;
                        float addNumber = System.Convert.ToSingle(addNum);

                        voltage2.transform.position = new Vector3(v2X, v2Y + addNumber, v2Z);
                    }

                    Debug.Log("Last y was " + _lastY.ToString("0.000"));

                    _lastY = _controller.Touch1PosAndForce.y;

                    Debug.Log("New y is " + _lastY.ToString("0.000"));

                    //Debug.Log("mag is " + _magnitude.ToString("0.000"));
                }
            }*/
        //}
    }
    

}
