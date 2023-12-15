using Calculations;
using FMODUnity;
using Managers;
using UnityEngine;

namespace Animation
{
    public class PassengerAnimationCheck : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Bridge"))
            {
                animator.SetTrigger("successBoat");
                
                // Task Done
                TaskManager.Instance.SetTaskToDone("Holidays");
            }

            if (other.gameObject.CompareTag("Taxi"))
            {
                animator.SetTrigger("accidentTaxi");
            
                // Task Done
                TaskManager.Instance.SetTaskToDone("Taxi to Heaven");
                
                // Sound
                Vector3 passengerPos = transform.position;
                RuntimeManager.PlayOneShot("event:/Sound/Accidents/WilhelmScream", passengerPos);
                
                // Vignette
                if (Camera.main == null) return;
                Vector2 originalVignettePos = Camera.main.WorldToScreenPoint(passengerPos);
                float x = ExtensionMethods.Remap(originalVignettePos.x, 0, Screen.width, 0, 1 );
                float y = ExtensionMethods.Remap(originalVignettePos.y, 0, Screen.height, 0, 1 );
                Debug.Log("Vignette Center: " + x + y);
                AccidentVignette.ShowAccidentVignette(new Vector2(x, y));
            }   

            if (other.gameObject.CompareTag("Shark"))
            {
                // Task Done
                TaskManager.Instance.SetTaskToDone("Here for the Goodies");

                // Play Sound
                Vector3 passengerPos = transform.position;
                RuntimeManager.PlayOneShot("event:/Sound/Accidents/SharkEatsPerson", passengerPos);
                RuntimeManager.PlayOneShot("event:/Sound/Accidents/WilhelmScream", passengerPos);
            
                Destroy(gameObject, 0.5f);

            }
        }
    }
}
