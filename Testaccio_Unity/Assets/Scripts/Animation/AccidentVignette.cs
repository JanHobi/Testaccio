using System;
using System.Collections;
using System.Linq;
using DG.Tweening;
using DG.Tweening.Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using FloatParameter = UnityEngine.Rendering.FloatParameter;
using Object = UnityEngine.Object;

namespace Animation
{
    public class AccidentVignette : MonoBehaviour
    {
        private static AccidentVignette instance;
        private VolumeProfile volumeProfile;
        UnityEngine.Rendering.Universal.Vignette vignette;
        [SerializeField] private float intensityWhenActive;
       
        private void Awake()
        {
            // Singleton pattern
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        void Start()
        {
            Invoke(nameof(GetVolume), 1);
        }

        private void GetVolume()
        {
            volumeProfile = GetComponent<Volume>()?.profile;
            if(!volumeProfile) throw new NullReferenceException(nameof(VolumeProfile));
        }

        public static void ShowAccidentVignette(Vector2 centerPos)
        {
            // Access the instance and call the function
            if (instance != null)
            {
                instance.InternalShowAccidentVignette(centerPos);
            }
        }

        private void InternalShowAccidentVignette(Vector2 centerPos)
        {
            if(!volumeProfile.TryGet(out vignette)) throw new NullReferenceException(nameof(vignette));
            
            
            DOTween.To(() => vignette.intensity.value, x => vignette.intensity.Override(x), intensityWhenActive, 0.2f)
                .OnComplete(() => StartCoroutine(WaitRoutine()));

            DOTween.To(() => vignette.center.value, x => vignette.center.Override(x), centerPos, 0.1f);
        }
        
        IEnumerator WaitRoutine()
        {
            yield return new WaitForSeconds(0.4f);
            ResetVignette();
        }

        private void ResetVignette()
        {
            if(!volumeProfile.TryGet(out vignette)) throw new NullReferenceException(nameof(vignette));
            
            
            // Use DoTween to animate back to the original values over time
            DOTween.To(() => vignette.intensity.value, x => vignette.intensity.Override(x), 0.3f, 0.3f);
            DOTween.To(() => vignette.center.value, x => vignette.center.Override(x), new Vector2(0.5f, 0.5f), 0.3f);
        }
    }
}
