﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public class SceneManagement : MonoBehaviour
    {

        private void Start()
        {

        }

        public void LoadLevel(int level)
        {
            SceneManager.LoadScene(level);
        }


    }
