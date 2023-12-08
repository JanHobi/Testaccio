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
        
        private List<GameObject> allClouds = new List<GameObject>();
        
        void Start()
        {
            GenerateClouds();
        }
        
        void GenerateClouds()
        {
            for (int i = 0; i < numberOfClouds; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(noiseStartX, noiseEndX),
                    cloudHeight,
                    Random.Range(noiseStartZ, noiseEndZ)
                );

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
                
                // Give it a random Move speed and then let the other script handle the movement
                float randomMoveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
                
                // Give them all a Move script and hand over a value to it. Divide with the Size of the Cloud --> larger ones are slower
                cloudInstance.AddComponent<MoveCloud>()
                    .SetMoveSpeed(randomMoveSpeed/randomScale);
                
                // Add to List for later use
                allClouds.Add(cloudInstance);
            }
        }
    }
}
