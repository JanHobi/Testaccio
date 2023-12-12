using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class RodFish : MonoBehaviour
    {
        [SerializeField] private GameObject fishPrefab;
        [SerializeField] private Animator fisherAnimator;
        private GameObject fishInstance;
        private GameObject water;
        private Transform hook;
        private bool caught;
        
        private void Start()
        {
            water = GameObject.FindGameObjectWithTag("WaterTrigger");
        }

        private void Update()
        {
            if (!caught) return;
            hook = transform;
            fishInstance.transform.position = hook.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Fish")
            {
                fishInstance = Instantiate(fishPrefab, null);
                fisherAnimator.SetTrigger("successFish");
                caught = true;
            }

            if (other.gameObject.tag == "Market")
            {
                caught = false;
                Destroy(fishInstance);
                fisherAnimator.SetTrigger("soldFish");
            }
        }
    }
}