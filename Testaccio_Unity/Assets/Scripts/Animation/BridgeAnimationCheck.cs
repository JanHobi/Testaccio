using FMODUnity;
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
                RuntimeManager.PlayOneShot("event:/Sound/BridgeDown", transform.position);
            }   

            if (other.gameObject.CompareTag("Passenger"))
            {
                // Task Done
                TaskManager.Instance.SetTaskToDone("Watch your Head");
                
                // Sounds
                var position = transform.position;
                RuntimeManager.PlayOneShot("event:/Sound/BridgeDown", position);
                RuntimeManager.PlayOneShot("event:/Sound/Accidents/WilhelmScream", position);
                
                // Vignette
                AccidentVignette.ShowAccidentVignette(position);

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
