using System.Collections.Generic;
using UnityEngine;

namespace Animation
{
    public class SpawnPassenger : MonoBehaviour
    {
        public GameObject passengerPrefab;
        public GameObject spawnPoint;
        [HideInInspector] public List<GameObject> allPassengers = new List<GameObject>();

        public void InstantiatePassenger()
        {
            GameObject instance =  Instantiate(passengerPrefab, spawnPoint.transform.position, Quaternion.identity);
            allPassengers.Add(instance);
        }
    }
}
