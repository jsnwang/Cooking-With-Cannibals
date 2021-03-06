﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Cut
{
    public class Cuttable : MonoBehaviour
    {
        [Header("Chopping")]
        public GameObject choppedObject;
        public int numChopsNeeded;

        private int numChops;
        private bool canChop = true;

        [Header("Cutting Progress UI")]
        public Slider progressSlider;
        public GameObject progressBar;
        private Camera cam;

        void Start()
        {
            // Set up slider
            progressSlider.maxValue = numChopsNeeded;
        }

        void Update()
        {
            if (cam == null)
            {
                cam = Camera.main;
            }

            if (cam != null)
            {
                progressBar.transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward);
            }
        }

        void Chop()
        {
            progressBar.SetActive(true);

            if (canChop)
            {
                numChops += 1;
                progressSlider.value = numChops;
            }
        }

        void CheckChopped()
        {
            if (numChops >= numChopsNeeded)
            {
                Vector3 pos = gameObject.transform.position;
                Quaternion rot = gameObject.transform.rotation;

                gameObject.SetActive(false);
                Instantiate(choppedObject, pos, rot);
                Destroy(gameObject);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Knife"))
            {
                Chop();
                canChop = false;

                CheckChopped();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Knife"))
            {
                canChop = true;            }
        }

    }
}
