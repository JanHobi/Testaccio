using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class MarketAnimationCheck : MonoBehaviour
{
    [SerializeField] private GameObject marketFish;

    private void Start()
    {
        marketFish.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fisher"))
        {
            marketFish.SetActive(true);
            
            // Task Done
            TaskManager.Instance.SetTaskToDone("Fish to Market");
        }   

        if (other.gameObject.CompareTag("Passenger"))
        {
            marketFish.SetActive(false);
            
            // Task Done
            TaskManager.Instance.SetTaskToDone("Sold Fish");
        }
    }
}
