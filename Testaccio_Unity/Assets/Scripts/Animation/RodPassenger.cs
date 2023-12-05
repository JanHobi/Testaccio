using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class RodPassenger : MonoBehaviour
    {
        private GameObject water;
        [SerializeField] private SpawnPassenger taxi;
        [SerializeField] private GameObject emptyPassenger;
         private Transform hook;
        private bool caught;
        private Transform selectedPassenger;
        private GameObject emptyPassengerInstance;

        private void Start()
        {
            water = GameObject.FindGameObjectWithTag("WaterTrigger");
        }

        private void Update()
        {
            if (!caught) return;
            hook = transform;
            emptyPassengerInstance.transform.position = hook.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (taxi.allPassengers.Contains(other.gameObject))
            {
                selectedPassenger = other.transform;
                Destroy(other);
                emptyPassengerInstance = Instantiate(emptyPassenger, null);
                caught = true;
            }
            if (other.gameObject == water)
            {
                Debug.Log("hit water");
                caught = false;
            }
            
           
           
        }
    }
}
