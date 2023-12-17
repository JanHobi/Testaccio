using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodTrigger : MonoBehaviour
{
    [SerializeField] private GameObject bloodParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Passenger"))
        {
            Instantiate(bloodParticles, transform.position, Quaternion.identity);
        }
    }
}
