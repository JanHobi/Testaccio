using FMOD.Studio;
using FMODUnity;
using Managers;
using UnityEngine;

namespace Animation
{
    public class FisherAnimationCheck : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Taxi"))
            {
                animator.SetTrigger("accidentTaxi");
            
                // Task Done
                TaskManager.Instance.SetTaskToDone("Car Accident");
            
                // Play Sound
                RuntimeManager.PlayOneShot("event:/Accidents/WilhelmScream", gameObject.transform.position);
            }   

            if (other.gameObject.CompareTag("Shark"))
            {
                animator.SetTrigger("accidentShark");
            
                // Task Done
                TaskManager.Instance.SetTaskToDone("Big Catch");
            }
        }
    }
}
