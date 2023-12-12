using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

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
        }   

        if (other.gameObject.CompareTag("Shark"))
        {
            animator.SetTrigger("accidentShark");
            
            // Task Done
            TaskManager.Instance.SetTaskToDone("Hungry Shark");
        }
    }
}
