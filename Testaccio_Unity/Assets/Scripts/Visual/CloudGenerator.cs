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
        [SerializeField] private Material cloudMaterial;
        [SerializeField] private int numberOfClouds;
        [SerializeField] private float cloudScale;
        [SerializeField] private float minMoveSpeed;
        [SerializeField] private float maxMoveSpeed;
        [SerializeField] private float minSingleScale;
        [SerializeField] private float maxSingleScale;
        [SerializeField] private float cloudHeight;
        [SerializeField] private float noiseStartX;
        [SerializeField] private float noiseEndX;
        [SerializeField] private float noiseStartZ;
        [SerializeField] private float noiseEndZ;
        [SerializeField] private int numberOfSpheresPerCloud;

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
            Vector3[] spherePositions = GenerateSpherePositions();

            GameObject cloudInstance = new GameObject("Cloud");
            
            foreach (var randomPos in spherePositions)
            {
                // Create sphere
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                // Random Size
                float randomSize = Random.Range(0.4f, 1.3f); 
                sphere.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
                // Make it a child of instance
                sphere.transform.parent = cloudInstance.transform;
                // Put to defined random Pos
                sphere.transform.position = randomPos;
                // Material
                sphere.GetComponent<Renderer>().material = cloudMaterial;
            }
            
            Vector3 randomPosition = RandomCloudPosition();

            // Use Perlin Nose
            float perlinX = randomPosition.x / cloudScale;
            float perlinZ = randomPosition.z / cloudScale;
            float perlinValue = Mathf.PerlinNoise(perlinX, perlinZ);

            // Adjust the cloud height based on the perlin value
            randomPosition.y += perlinValue;

            cloudInstance.transform.position = randomPosition;

            // Add random scaling to the cloud
            float randomScale = Random.Range(minSingleScale, maxSingleScale); // Adjust the range as needed

            Vector3 randomScaleVector = new Vector3(randomScale, randomScale, randomScale);
            
            // Set the rotation to a 90-degree rotation around the X-axis
            //Quaternion rotation = Quaternion.Euler(90f, 0f, 0f);

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

        private Vector3[] GenerateSpherePositions()
        {
            // Generate random center Points for the Spheres
            Vector3[] positions = new Vector3[numberOfSpheresPerCloud];

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = new Vector3(Random.Range(-0.5f, 0.5f)
                    , Random.Range(-0.5f, 0.5f)
                    , Random.Range(-0.5f, 0.5f));
            }

            return positions;
        }

        private void RemoveOldAndSpawnNewClouds()
        {
            // Create a seperate List for the clouds that need to be removed. Cannot delete objs out of a list while looping through it...
            List<GameObject> cloudsToRemove = new List<GameObject>();

            for (var index = 0; index < allClouds.Count; index++)
            {
                var cloud = allClouds[index];
                if (!(cloud.transform.position.x > noiseEndX)) continue;
                
                // Add this cloud to List of removable clouds
                cloudsToRemove.Add(cloud);
                // Now only spawn outside the screen
                emptySky = false;
                // Spawn a new one
                SpawnCloud();
            }

            // Remove the selected clouds
            foreach (GameObject fluffy in cloudsToRemove)
            {
                allClouds.Remove(fluffy);
                Destroy(fluffy);
            }
        }

        private Vector3 RandomCloudPosition()
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
