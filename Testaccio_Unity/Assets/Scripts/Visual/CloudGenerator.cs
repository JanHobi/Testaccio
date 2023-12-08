using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

namespace Visual
{
    public class CloudGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject cloudPrefab;
        [SerializeField] private int numberOfClouds;
        [SerializeField] private float cloudScale;
        [SerializeField] private float minMoveSpeed;
        [SerializeField] private float maxMoveSpeed;
        [SerializeField] private float cloudHeight;
        [SerializeField] private float noiseStartX;
        [SerializeField] private float noiseEndX;
        [SerializeField] private float noiseStartZ;
        [SerializeField] private float noiseEndZ;

        private bool emptySky;
        private List<GameObject> allClouds = new List<GameObject>();
        
        void Start()
        {
            emptySky = true;
            GenerateClouds();
        }
        
        private void Update()
        {
            RemoveOldAndSpawnNewClouds();
            
        }
        
        void GenerateClouds()
        {
            for (int i = 0; i < numberOfClouds; i++)
            {
                SpawnCloud();
            }
        }

        private void SpawnCloud()
        {
            Vector3 randomPosition = GenerateRandomPosition();

            float perlinX = randomPosition.x / cloudScale;
            float perlinZ = randomPosition.z / cloudScale;

            float perlinValue = Mathf.PerlinNoise(perlinX, perlinZ);

            // Adjust the cloud height based on the perlin value
            randomPosition.y += perlinValue;

            // Add random scaling to the cloud
            float randomScale = Random.Range(10f, 30f); // Adjust the range as needed

            Vector3 randomScaleVector = new Vector3(randomScale, randomScale, randomScale);
                
            // Set the rotation to a 90-degree rotation around the X-axis
            Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);

            // Instantiate
            GameObject cloudInstance = Instantiate(cloudPrefab, randomPosition, rotation);

            // Add random scaling
            cloudInstance.transform.localScale = randomScaleVector;
                
            // random Move speed
            float randomMoveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
                
            // Give them all a Move script and hand over the move value. Divide with the Size of the Cloud --> larger ones are slower
            cloudInstance.AddComponent<MoveCloud>()
                .SetMoveSpeed(randomMoveSpeed/randomScale);
                
            // Add to List for later use
            allClouds.Add(cloudInstance);
        }
        
        private void RemoveOldAndSpawnNewClouds()
        {
            // Create a seperate List for the clouds that need to be removed. Cannot delete objs out of a list while looping through it...
            List<GameObject> cloudsToRemove = new List<GameObject>();

            for (var index = 0; index < allClouds.Count; index++)
            {
                var cloud = allClouds[index];
                if (!(cloud.transform.position.x > noiseEndX)) continue;
                cloudsToRemove.Add(cloud);
                SpawnCloud();
            }

            // Remove the selected clouds
            foreach (GameObject fluffy in cloudsToRemove)
            {
                allClouds.Remove(fluffy);
                Destroy(fluffy);
            }
        }

        private Vector3 GenerateRandomPosition()
        {
            if (emptySky)
            {
                return new Vector3(
                    Random.Range(noiseStartX, noiseEndX),
                    cloudHeight,
                    Random.Range(noiseStartZ, noiseEndZ)
                );
            }
            else
            {
               return new Vector3(
                    Random.Range(noiseStartX-100, noiseStartX),
                    cloudHeight,
                    Random.Range(noiseStartZ, noiseEndZ)
                );
            }
        }
    }
}
