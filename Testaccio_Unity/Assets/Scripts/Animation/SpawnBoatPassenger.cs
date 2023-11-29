using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoatPassenger : MonoBehaviour
{
    [SerializeField] public GameObject boatPassenger;

    public void BoatPassengerSpawn()
    {
            Instantiate(boatPassenger, transform.position, Quaternion.identity, transform);
    }

}
