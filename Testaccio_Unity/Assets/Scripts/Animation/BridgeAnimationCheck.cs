using Managers;
using UnityEngine;

namespace Animation
{
    public class BridgeAnimationCheck : MonoBehaviour
    {
        [SerializeField] private GameObject bridgeTrigger;

        private void Start()
        {
            bridgeTrigger.SetActive(false);
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {            
                bridgeTrigger.SetActive(true);
            }   

            if (other.gameObject.CompareTag("Passenger"))
            {
                // Task Done
                TaskManager.Instance.SetTaskToDone("Watch your Head");
            
                Debug.Log("passenger death by bridge");
                Destroy(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {          
                bridgeTrigger.SetActive(false);
            }  
        }
    }
}
