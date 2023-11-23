using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPassenger : MonoBehaviour
{
    public GameObject passengerPrefab;
    public GameObject spawnPoint;

    public void InstantiatePassenger()
    {
        Instantiate(passengerPrefab, spawnPoint.transform.position, Quaternion.identity);
    }
}
