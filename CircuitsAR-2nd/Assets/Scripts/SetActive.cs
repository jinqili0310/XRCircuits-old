using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class SetActive : MonoBehaviour
{
    public GameObject Menu;

    public GameObject Instructions;

    public GameObject RValue;
    public GameObject CValue;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);

        Instructions.SetActive(false);

        RValue.SetActive(false);
        CValue.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(voltage2.activeSelf.ToString());
    }
}
