using DG.Tweening;
using UnityEngine;

namespace Animation
{
    public class SmallAnimations : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectToAnimate;

        public void BridgeOpen()
        {
            gameObjectToAnimate.transform.DOLocalRotate(new Vector3(0, 0, -96), 0.7f).SetEase(Ease.InExpo);
        }

        public void BridgeClose()
        {
            gameObjectToAnimate.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.7f).SetEase(Ease.OutBounce);
        }

        public void LungeRod()
        {
            gameObjectToAnimate.transform.DOLocalMove(new Vector3(9f, 1.4f, 5.5f), 0.8f).SetEase(Ease.InOutQuint);
        }

        public void ThrowRod()
        {
            gameObjectToAnimate.transform.DOLocalMove(new Vector3(-18.6f, 5.2f, -17.5f), 1).SetEase(Ease.InOutQuint);
        }
        
        public void TakeRodBack()
        {
            gameObjectToAnimate.transform.DOLocalMove(new Vector3(-0.84f, 9.35f, -0.81f), 1).SetEase(Ease.InOutQuint);
        }

        public void OpenCottageDoor()
        {
            gameObjectToAnimate.transform.DOLocalRotate(new Vector3(0, 90, 0), 0.7f).SetEase(Ease.InOutQuint);
        }

        public void CloseCottageDoor()
        {
            gameObjectToAnimate.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.7f).SetEase(Ease.InOutQuint);
        }
        
    }
}
