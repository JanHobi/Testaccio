using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrigger : MonoBehaviour
{
    [SerializeField] private GameObject dustParticles;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BridgeAccident"))
        {
            Instantiate(dustParticles, transform.position, Quaternion.identity);
        }
    }
}
