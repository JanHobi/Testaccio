using FMOD.Studio;
using FMODUnity;
using Managers;
using UnityEngine;

namespace Audio
{
    public class OceanSound : MonoBehaviour
    {
        private EventInstance waveSound;
        
        // Start is called before the first frame update
        void Start()
        {
            if (GameManager.instance.currentGameState != GameManager.GameState.InGame) return;
            waveSound = RuntimeManager.CreateInstance("event:/Sound/SmallWaves");
            GameObject emitter = gameObject;
            waveSound.set3DAttributes(emitter.To3DAttributes());
            waveSound.start();
        }
    }
}
