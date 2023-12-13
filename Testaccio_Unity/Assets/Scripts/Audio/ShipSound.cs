using System.Collections;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Audio
{
    public class ShipSound : MonoBehaviour
    {
        private EventInstance ferryMotor;

        private void Start()
        {
            ferryMotor = RuntimeManager.CreateInstance("event:/Sound/FerryMotor");
            ferryMotor.set3DAttributes(gameObject.To3DAttributes());
            
                ferryMotor.start();
                StartCoroutine(WaitForHonk());
        }

        private IEnumerator WaitForHonk()
      {
          float randomWaitTime = Random.Range(10, 20);
          yield return new WaitForSeconds(randomWaitTime);
        
          RuntimeManager.PlayOneShot("event:/Sound/FerryHonk", gameObject.transform.position);
      }
    }
}
