using Managers;
using UnityEngine;

namespace Animation
{
    public class MarketAnimationCheck : MonoBehaviour
    {
        [SerializeField] private GameObject marketFish;

        private void Start()
        {
            marketFish.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Fisher"))
            {
                marketFish.SetActive(true);
            
                // Task Done
                TaskManager.Instance.SetTaskToDone("Fish to Market");
            }   

            if (other.gameObject.CompareTag("Passenger"))
            {
                if (!marketFish.activeSelf) return;
                // Task Done
                TaskManager.Instance.SetTaskToDone("Comfort Dinner");
                
                // Vignette
                AccidentVignette.ShowAccidentVignette(transform.position);
                
                marketFish.SetActive(false);
            }
        }
    }
}
