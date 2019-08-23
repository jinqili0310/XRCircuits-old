using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;


public class hideInstructor : MonoBehaviour
{
    public GameObject InstructorVideo;
    public GameObject SimulationVideo2;
    public GameObject SimulationVideo3;
    public GameObject Diagram2;
    public GameObject Diagram3;
    public GameObject InstructionFrame;

    // Start is called before the first frame update
    void Start()
    {
        InstructorVideo.SetActive(false);
        SimulationVideo2.SetActive(false);
        SimulationVideo3.SetActive(false);
        Diagram2.SetActive(false);
        Diagram3.SetActive(false);
        InstructionFrame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
