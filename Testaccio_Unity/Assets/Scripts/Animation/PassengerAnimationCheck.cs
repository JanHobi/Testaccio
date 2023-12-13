using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

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
        }   

        if (other.gameObject.CompareTag("Shark"))
        {
            // Task Done
            TaskManager.Instance.SetTaskToDone("Here for the Goodies");
            
            Destroy(gameObject, 0.5f);

        }
    }
}
