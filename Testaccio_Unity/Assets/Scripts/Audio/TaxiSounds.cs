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

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Passenger") && !other.gameObject.CompareTag("Fisher")) return;
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
