using System;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;
using Unity.VisualScripting;

namespace Audio
{
    public class TaxiSounds : MonoBehaviour
    {
        private EventInstance motorSound;
        private void Start()
        {
            motorSound = RuntimeManager.CreateInstance("event:/Sound/TaxiMotor");
            motorSound.set3DAttributes(gameObject.To3DAttributes());
            motorSound.start();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag("Passenger")) return;
            Debug.Log("Crash Sound");
            Vector3 taxiPos = gameObject.transform.position;
            RuntimeManager.PlayOneShot("event:/Sound/Accidents/CarCrash", taxiPos);
        }

        private void OnDisable()
        {
            motorSound.release();
        }
    }
}
