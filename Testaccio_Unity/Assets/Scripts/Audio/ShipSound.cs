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
        private EventInstance shipWaves;

        private void Start()
        {
            ferryMotor = RuntimeManager.CreateInstance("event:/Sound/FerryMotor");
            shipWaves = RuntimeManager.CreateInstance("event:/Sound/MenuShip");

            shipWaves.set3DAttributes(gameObject.To3DAttributes());
            ferryMotor.set3DAttributes(gameObject.To3DAttributes());
            
                ferryMotor.start();
                shipWaves.start();
                StartCoroutine(WaitForHonk());
        }

        private IEnumerator WaitForHonk()
      {
          float randomStartDelay = Random.Range(5, 30);
          yield return new WaitForSeconds(randomStartDelay);
          
          while (true)
          {
              RuntimeManager.PlayOneShot("event:/Sound/FerryHonk", gameObject.transform.position);
              float randomWaitTime = Random.Range(10, 20);
              yield return new WaitForSeconds(randomWaitTime);
          }
      }
    }
}
