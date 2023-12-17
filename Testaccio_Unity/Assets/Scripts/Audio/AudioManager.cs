using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        //private static AudioManager _instance;
        private FMOD.Studio.EventInstance menuMusic;
        private FMOD.Studio.EventInstance gameMusic;
        private FMOD.Studio.EventInstance harborBackgroundNoise;
        private FMOD.Studio.EventInstance hover;
        private FMOD.Studio.EventInstance click;
        private FMOD.Studio.EventInstance taskDone;
        private EventInstance seagulls;
        private EventInstance menuShip;
        private EventInstance deepOceanWaves;
        private List<EventInstance> uiSounds = new List<EventInstance>();

        public static AudioManager Instance;
     

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else
            {
                Debug.Log("Deleting a second instance of AudioManager");
                Destroy(gameObject);
                return;
            }
            
            DontDestroyOnLoad(Instance);

            // Create All instances
            hover = RuntimeManager.CreateInstance("event:/Sound/UI/ButtonHover");
            click = RuntimeManager.CreateInstance("event:/Sound/UI/ButtonClick");
            taskDone = RuntimeManager.CreateInstance("event:/Sound/UI/TaskDone");
           
            
            // UI Sounds List
            uiSounds.Add(hover);
            uiSounds.Add(click);
            uiSounds.Add(taskDone);
        }

        public void PlayMenuMusic()
        {
            menuMusic = RuntimeManager.CreateInstance("event:/MenuMusic");

            gameMusic.stop(STOP_MODE.ALLOWFADEOUT);
            //gameMusic.release();
            menuMusic.start();
        }
        public void PlayGameMusic()
        {
            gameMusic = RuntimeManager.CreateInstance("event:/InGameMusic");
            
            menuMusic.stop(STOP_MODE.ALLOWFADEOUT);
           // menuMusic.release();
            gameMusic.start();
        }

        public void StopGameMusic()
        {
            gameMusic.stop(STOP_MODE.ALLOWFADEOUT);
        }
        public void StopMenuMusic()
        {
            menuMusic.stop(STOP_MODE.ALLOWFADEOUT);
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

        public void PlayMenuBackgroundSounds()
        {
            deepOceanWaves = RuntimeManager.CreateInstance("event:/Sound/OceanAmbiance");
            seagulls = RuntimeManager.CreateInstance("event:/Sound/Seagulls");
            
            deepOceanWaves.start();
            seagulls.start();
        }

        public void StopMenuBackgroundSounds()
        {
            deepOceanWaves.stop(STOP_MODE.ALLOWFADEOUT);
            deepOceanWaves.release();
        }

        public void PlayInGameBackgroundSounds()
        {
            harborBackgroundNoise = RuntimeManager.CreateInstance("event:/Sound/HarborBackgroundNoise");
            harborBackgroundNoise.start();
        }

        public void StopInGameBackgroundSounds()
        {
            harborBackgroundNoise.stop(STOP_MODE.IMMEDIATE);
            harborBackgroundNoise.release();
        }

        public void PlayUISound(int index)
        {
            uiSounds[index].start();
        }

        public void PlayObjectHoverSound()
        {
            RuntimeManager.PlayOneShot("event:/Sound/UI/ObjectHover");
        }
        
        public void PlayObjectClickSound()
        {
            RuntimeManager.PlayOneShot("event:/Sound/UI/ObjectClick");
        }
        
        public void PlayCircleClickSound()
        {
            RuntimeManager.PlayOneShot("event:/Sound/UI/CircleClick");
        }
    }
}
