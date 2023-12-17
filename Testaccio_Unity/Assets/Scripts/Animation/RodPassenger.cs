using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
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
            taxi = FindObjectOfType<SpawnPassenger>();
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
                Debug.Log("hit passenger");
                selectedPassenger = other.transform;
                Destroy(other.gameObject);
                RuntimeManager.PlayOneShot("event:/Sound/Accidents/PersonCaughtByFisher", transform.position);
                
                emptyPassengerInstance = Instantiate(emptyPassenger, null);
                caught = true;
            }
            if (other.gameObject == water)
            {
                RuntimeManager.PlayOneShot("event:/Sound/Accidents/PersonIntoWater", transform.position);
                Debug.Log("hit water");
                caught = false;
            }
        }
    }
}
