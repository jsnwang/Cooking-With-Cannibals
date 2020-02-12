﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class PlayButton : MonoBehaviour
{
    public VRTK_InteractableObject interactableObject;
    private void Update()
    {
        if (interactableObject.IsTouched())
        {

            LevelManager.Instance.LoadScene(1);
        }
    }
}