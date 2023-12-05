using System;
using UnityEngine;


public class SharkAccidents : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            Debug.Log("Shark McSharkface was killed :(");
            animator.SetTrigger("accidentShip");
        }

        if (other.gameObject.CompareTag("Passenger"))
        {
            Debug.Log("Passenger was eaten by shark");
            //add effects here?
        }
    }
}
