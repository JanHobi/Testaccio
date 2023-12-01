using System;
using UnityEngine;

namespace Animation
{
    public class SharkBoatCrash : MonoBehaviour
    {
        [SerializeField] private GameObject ship;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject != ship) return;
            Debug.Log("Shark McSharkface was killed :(");
            Destroy(gameObject);
        }
    }
}
