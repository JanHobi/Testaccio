using DG.Tweening;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Animation
{
    public class SmallAnimations2 : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectToAnimate;

        public void OpenCottageDoor()
        {
            gameObjectToAnimate.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.3f).SetEase(Ease.OutBack);
        }

        public void CloseCottageDoor()
        {
            gameObjectToAnimate.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.6f).SetEase(Ease.InBack);
        }
        
    }
}
