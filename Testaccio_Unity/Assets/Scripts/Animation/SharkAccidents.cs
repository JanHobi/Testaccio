using System;
using UnityEngine;

namespace Animation
{
    public class SharkAccidents : MonoBehaviour
    {
        [SerializeField] private GameObject ship;
        [SerializeField] private GameObject passengerPrefab;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == ship)
            {
                Debug.Log("Shark McSharkface was killed :(");
                Destroy(gameObject);
            }
            else if (collision.gameObject == passengerPrefab)
            {
                Debug.Log("Passenger was eaten by shark");
                Destroy(passengerPrefab); 
            }
        }
    }
}
