using System;
using System.Collections;
using Calculations;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;


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

        public static void ShowAccidentVignette(Vector3 pos)
        {
            // Access the instance and call the function
            if (instance != null)
            {
                instance.InternalShowAccidentVignette(pos);
            }
        }

        private void InternalShowAccidentVignette(Vector3 pos)
        {
            if(!volumeProfile.TryGet(out vignette)) throw new NullReferenceException(nameof(vignette));
            
           Vector2 centerPos = TranslateObjectPosToScreenPos(pos);
            
            DOTween.To(() => vignette.intensity.value, x => vignette.intensity.Override(x), intensityWhenActive, 0.2f)
                .OnComplete(() => StartCoroutine(WaitRoutine()));

            DOTween.To(() => vignette.center.value, x => vignette.center.Override(x), centerPos, 0.1f);

            vignette.smoothness.value = 0;
        }

        private Vector2 TranslateObjectPosToScreenPos(Vector3 pos)
        {
            if (Camera.main == null) return default;
            Vector2 originalVignettePos = Camera.main.WorldToScreenPoint(pos);
            float x = ExtensionMethods.Remap(originalVignettePos.x, 0, Screen.width, 0, 1 );
            float y = ExtensionMethods.Remap(originalVignettePos.y, 0, Screen.height, 0, 1 );
            return new Vector2(x, y);
        }

        IEnumerator WaitRoutine()
        {
            yield return new WaitForSeconds(0.6f);
            ResetVignette();
        }

        private void ResetVignette()
        {
            if(!volumeProfile.TryGet(out vignette)) throw new NullReferenceException(nameof(vignette));
            
            
            // Use DoTween to animate back to the original values over time
            DOTween.To(() => vignette.intensity.value, x => vignette.intensity.Override(x), 0.3f, 0.3f);
            DOTween.To(() => vignette.center.value, x => vignette.center.Override(x), new Vector2(0.5f, 0.5f), 0.3f);
            vignette.smoothness.value = 0.14f;
        }
    }
}
