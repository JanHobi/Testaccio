using System;
using System.Collections;
using UnityEngine;
using FMOD;
using FMODUnity;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;
        private FMOD.Studio.EventInstance menuMusic;
        private FMOD.Studio.EventInstance gameMusic;
        
        public static AudioManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    Debug.Log("AudioManager is null!");
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null) _instance = this;
            else
            {
                Debug.Log("Deleting a second instance of AudioManager");
                Destroy(gameObject);
                return;
            }
            
            DontDestroyOnLoad(_instance);

            menuMusic = RuntimeManager.CreateInstance("event:/MenuMusic");
            gameMusic = RuntimeManager.CreateInstance("event:/InGameMusic");
        }

        public void PlayMenuMusic()
        {
            gameMusic.stop(STOP_MODE.ALLOWFADEOUT);
            menuMusic.start();
        }
        public void PlayGameMusic()
        {
            menuMusic.stop(STOP_MODE.ALLOWFADEOUT);
            gameMusic.start();
        }

        public void ChangeMusicSpeed(float value)
        {
            gameMusic.setParameterByName("MusicSpeed", value: value);
            StartCoroutine(routine: WaitAndResetSpeed()); 

            IEnumerator WaitAndResetSpeed()
            {
                yield return new WaitForSeconds(5);
                Debug.Log(message: "Resetting Music Speed");
                gameMusic.setParameterByName("MusicSpeed", value: 0);
            }
        }

        private void Update()
        {
            // Log the current value of the "Speed" parameter
            float currentSpeedValue;
            gameMusic.getParameterByName("MusicSpeed", out currentSpeedValue);
            Debug.Log(message: $"Current Music Speed: {currentSpeedValue}");
        }
    }
}
