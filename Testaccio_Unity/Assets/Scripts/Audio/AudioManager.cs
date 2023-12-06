using System;
using UnityEngine;
using FMOD;
using FMODUnity;
using Debug = UnityEngine.Debug;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;
        private FMOD.Studio.EventInstance menuMusic = RuntimeManager.CreateInstance("event/menuMusic");
        private FMOD.Studio.EventInstance gameMusic = RuntimeManager.CreateInstance("event/gameMusic");
        
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
            _instance = this;
        }

        public void PlayMenuMusic()
        {
            menuMusic.start();
        }
        public void PlayGameMusic()
        {
            gameMusic.start();
        }
    }
}
