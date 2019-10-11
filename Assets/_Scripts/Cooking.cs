﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    #region Variables

    //[SerializeField]
    //private Material raw;

    [SerializeField]
    private Shader cooked;

    [SerializeField]
    private Material burnt;
    
    [SerializeField]
    private Renderer rend;

    private float timeCooked;

    private bool isCooked = false;

    #endregion Variables

    // Start is called before the first frame update
    void Start()
    {
        timeCooked = 0;
        cooked = Shader.Find("_albedoCooked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Pan"))
        {
            
            
            if (isCooked == false)
            {
                if (timeCooked < 5)
                {
                    timeCooked += Time.deltaTime;
                    Debug.Log("Cooking TIme: " + timeCooked + " seconds");
                }
                else
                {
                    rend.material.shader = cooked;
                    //gameObject.SetActive(false);
                    isCooked = true;
                    Debug.Log("Object is cooked");
                }
            }
        }
    }

    /**
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Detected");
        if (other.gameObject.CompareTag("Pan"))
        {
            if (isCooked == false)
            {
                rend.material = cooked;
                //gameObject.SetActive(false);
                isCooked = true;
                Debug.Log("Object is cooked");
            }
        }
    }
    **/
}