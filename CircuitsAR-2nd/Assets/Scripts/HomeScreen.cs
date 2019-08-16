using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MagicLeap
{

public class HomeScreen : MonoBehaviour
{

    //public GameObject ImageInstruction;
    //public GameObject CycleInstruction;

    private void Start()
        {
            //ImageInstruction.SetActive(false);
            //CycleInstruction.SetActive(false);
        }

    /*public void ImageInst()
        {
            ImageInstruction.SetActive(true);
        }

    public void CycleInst()
        {
            CycleInstruction.SetActive(true);
        }

    public void GoBack()
        {
            ImageInstruction.SetActive(false);
            CycleInstruction.SetActive(false);
        }*/

    public void KCLEnter()
        {
            SceneManager.LoadScene(sceneName: "KCLMode");
        }

    public void TEEnter()
        {
            SceneManager.LoadScene(sceneName: "TEMode");
        }

}

}