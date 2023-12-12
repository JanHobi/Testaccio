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
            ferryMotor.set3DAttributes(RuntimeUtils.To3DAttributes(gameObject));
            
                ferryMotor.start(); 
                RuntimeManager.PlayOneShot("event:/Sound/FerryHonk", gameObject.transform.position);
                //StartCoroutine(WaitForHonk());
        }

        private IEnumerator WaitForHonk()
      {
          float randomWaitTime = Random.Range(2, 5);
          yield return new WaitForSeconds(randomWaitTime);
        
          RuntimeManager.PlayOneShot("event:/Sound/FerryHonk", gameObject.transform.position);
      }
    }
}
