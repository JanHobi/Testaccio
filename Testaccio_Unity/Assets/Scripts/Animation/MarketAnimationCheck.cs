using Managers;
using UnityEngine;

namespace Animation
{
    public class MarketAnimationCheck : MonoBehaviour
    {
        [SerializeField] private GameObject marketFish;
        [SerializeField] private GameObject marketSignFreshFish;
        [SerializeField] private GameObject marketSignSoldOut;

        private void Start()
        {
            marketFish.SetActive(false);
            marketSignFreshFish.SetActive(false);
            marketSignSoldOut.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Fisher"))
            {
                marketFish.SetActive(true);
                marketSignFreshFish.SetActive(true);
                marketSignSoldOut.SetActive(false);
            
                // Task Done
                TaskManager.Instance.SetTaskToDone("Fish to Market");
            }   

            if (other.gameObject.CompareTag("Passenger"))
            {
                if (!marketFish.activeSelf) return;
                marketSignFreshFish.SetActive(false);
                marketSignSoldOut.SetActive(true);
                // Task Done
                TaskManager.Instance.SetTaskToDone("Comfort Dinner");
                
                // Vignette
                AccidentVignette.ShowAccidentVignette(transform.position);
                
                marketFish.SetActive(false);
            }
        }
    }
}
