using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dustParticles;
    [SerializeField] private GameObject dustPosition;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bridge"))
        {
            Debug.Log("Dust Triggered");
            Instantiate(dustParticles, dustPosition.transform.position, Quaternion.identity);
        }
    }
}
