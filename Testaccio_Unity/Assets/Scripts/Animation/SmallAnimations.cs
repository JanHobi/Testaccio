using DG.Tweening;
using UnityEngine;

namespace Animation
{
    public class SmallAnimations : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectToAnimate;

        public void BridgeOpen()
        {
            gameObjectToAnimate.transform.DOLocalRotate(new Vector3(80, 0, 0), 0.7f).SetEase(Ease.InExpo);
        }

        public void BridgeClose()
        {
            gameObjectToAnimate.transform.DOLocalRotate(new Vector3(-22, 0, 0), 0.7f).SetEase(Ease.OutBounce);
        }

        public void LungeRod()
        {
            gameObjectToAnimate.transform.DOLocalMove(new Vector3(-1.3f, 0.37f, -1.5f), 0.8f).SetEase(Ease.InOutQuint);
        }

        public void ThrowRod()
        {
            gameObjectToAnimate.transform.DOLocalMove(new Vector3(5.8f, 1.65f, 5.4f), 1).SetEase(Ease.InOutQuint);
        }
        
        public void TakeRodBack()
        {
            gameObjectToAnimate.transform.DOLocalMove(new Vector3(0.01f, 1.436f, -0.06f), 1).SetEase(Ease.InOutQuint);
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
