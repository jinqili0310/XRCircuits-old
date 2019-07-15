using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class SetActive : MonoBehaviour
{
    public GameObject VoltageButton;
    public GameObject VoltageValues;
    public GameObject VoltageValue1;
    public GameObject VoltageValue2;
    public GameObject VoltageValue3;

    // Start is called before the first frame update
    void Start()
    {
        VoltageButton = GameObject.Find("VoltageButton");
        VoltageValues = GameObject.Find("VoltageValues");
        VoltageValue1 = GameObject.Find("VoltageValue1");
        VoltageValue2 = GameObject.Find("VoltageValue2");
        VoltageValue3 = GameObject.Find("VoltageValue3");

        VoltageValues.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(voltage2.activeSelf.ToString());
    }
}
