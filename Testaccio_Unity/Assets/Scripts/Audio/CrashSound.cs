using System;
using UnityEngine;
using FMODUnity;

namespace Audio
{
    public class CrashSound : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Passenger")) return;
            Debug.Log("Crash Sound");
            Vector3 taxiPos = gameObject.transform.position;
            RuntimeManager.PlayOneShot("event:/Sound/Accidents/CarCrash", taxiPos);
        }
    }
}
