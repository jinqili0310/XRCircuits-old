using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace MagicLeap 
{

public class CurrentValue : MonoBehaviour
{
    public LaunchManager launchManager;
    public ChangeMenu changeMenu;

    public GameObject[] values;
    private int index;

    //public string ChosenCurrentValue;

    public void ClickValue()
    {
        launchManager = GameObject.FindObjectOfType<LaunchManager> ();

        //ChosenCurrentValue = EventSystem.current.currentSelectedGameObject.name;

        for (int i = 0; i < values.Length; i++)
        {
            if (i == index)
                {
                    launchManager.NextCurrentValue = i + 1;
                }
        }

            changeMenu.ChangeCurrentValue();
    }
}

}