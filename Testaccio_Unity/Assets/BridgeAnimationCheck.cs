using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class BridgeAnimationCheck : MonoBehaviour
{
    [SerializeField] private GameObject bridgeTrigger;

    private void Start()
    {
        bridgeTrigger.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {            
            bridgeTrigger.SetActive(true);
        }   

        if (other.gameObject.CompareTag("Passenger"))
        {
            Debug.Log("passenger death by bridge");
            Destroy(other.gameObject);
            
            // Task Done
            TaskManager.Instance.SetTaskToDone("Heavy Bridge");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {          
            bridgeTrigger.SetActive(false);
        }  
    }
}
