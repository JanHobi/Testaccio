using System;
using UnityEngine;

namespace Animation
{
    public class RodPassenger : MonoBehaviour
    {
        [SerializeField] private GameObject passengerPrefab;
        [SerializeField] private GameObject water;
        private Transform hook;

        private void Start()
        {
            hook = transform;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == passengerPrefab)
            {
                Debug.Log("Fisher catches Passenger");
                passengerPrefab.transform.SetParent(transform);
            }
            else if (collision.gameObject == water)
            {
                // If he's in the water, remove parenting again
                passengerPrefab.transform.SetParent(null);
            }
        }
    }
}
