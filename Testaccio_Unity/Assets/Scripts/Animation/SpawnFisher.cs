using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class SpawnFisher : MonoBehaviour
{
    
    [SerializeField] private GameObject fisherPrefab;
    [SerializeField] private GameObject fisherSpawn;
    private KnobManager knobManager;

    
    private void Start()
    {
        knobManager = FindObjectOfType<KnobManager>();
    }

    private void SpawnNextFisher()
    {
        GameObject fisherInstance = Instantiate(fisherPrefab, fisherSpawn.transform.position, Quaternion.identity);
        knobManager.interactableObjects.Add(fisherInstance);
    }
}
