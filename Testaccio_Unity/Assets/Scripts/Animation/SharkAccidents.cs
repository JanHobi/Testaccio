using System;
using Managers;
using UnityEngine;


public class SharkAccidents : MonoBehaviour
{
    [SerializeField] private GameObject sharkPrefab;
    private Animator animator;
    private bool isDead = false;
    private KnobManager knobManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knobManager = FindObjectOfType<KnobManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ship") && !isDead)
        {
            animator.SetTrigger("accidentShip");
            isDead = true;
        }

        if (other.gameObject.CompareTag("Passenger"))
        {
            Debug.Log("Passenger was eaten by shark");
            //add effects here?
        }
    }

    private void SpawnNextShark()
    {
        GameObject sharkInstance = Instantiate(sharkPrefab, transform.position, Quaternion.identity);
        knobManager.interactableObjects.Add(sharkInstance);
    }
}
