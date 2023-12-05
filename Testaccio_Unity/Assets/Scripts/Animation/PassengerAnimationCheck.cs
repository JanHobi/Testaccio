using System.Collections;
using System.Collections.Generic;
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
        }

        if (other.gameObject.CompareTag("Taxi"))
        {
            animator.SetTrigger("accidentTaxi");
        }   

        if (other.gameObject.CompareTag("Shark"))
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
