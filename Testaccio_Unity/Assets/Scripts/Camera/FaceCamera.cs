using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    void Update()
    {
        // Get the direction from the sprite to the camera
        Vector3 directionToCamera = Camera.main.transform.position - transform.position;

        // Calculate the rotation to face the camera
        Quaternion rotationToCamera = Quaternion.LookRotation(directionToCamera);

        // Correct the orientation by rotating the sprite 180 degrees around the up axis (Y axis)
        rotationToCamera *= Quaternion.Euler(0, 180f, 0);

        // Apply the rotation to the sprite
        transform.rotation = rotationToCamera;
    }
}
