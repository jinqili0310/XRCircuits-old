using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructorControl : MonoBehaviour
{
    public GameObject InstructorVideo;

    bool InsIsOn = false;

    private void Start()
    {
        InstructorVideo.SetActive(false);
        InsIsOn = false;
    }

    public void ShowInstructor()
    {
        if (InsIsOn == false)
        {
            InstructorVideo.SetActive(true);
            InsIsOn = true;

        }
        else if (InsIsOn == true)
        {
            InstructorVideo.SetActive(false);
            InsIsOn = false;

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
