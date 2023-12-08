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
        [SerializeField] private float noiseStartY;
        [SerializeField] private float noiseEndY;
        
        private List<GameObject> allClouds = new List<GameObject>();


        void Start()
        {
            GenerateClouds();
        }

        private void Update()
        {
            MoveClouds();
        }

       

        void GenerateClouds()
        {
            for (int i = 0; i < numberOfClouds; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(noiseStartX, noiseEndX),
                    cloudHeight,
                    Random.Range(noiseStartY, noiseEndY)
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
                
                allClouds.Add(cloudInstance);
            }
        }
        
        private void MoveClouds()
        {
            foreach (var cloud in allClouds)
            {
                float randomMoveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
                cloud.transform.position -= new Vector3(1, 0, 0) * randomMoveSpeed;
            }
        }
    }
}
