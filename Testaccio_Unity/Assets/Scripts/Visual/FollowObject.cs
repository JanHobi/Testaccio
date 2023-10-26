using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // Reference to the 3D object you want to follow
    public float scaleFactor = 1f; // Scaling factor for the frame
    public float minScale = 0.5f; // Minimum scale for the frame
    public float maxScale = 2f; // Maximum scale for the frame
    CameraController cameraController;

    void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    void Update()
    {
        if (target != null)
        {
            // Get the 3D object's position in screen space
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);

            // Set the Canvas position to the 3D object's screen position
            transform.position = screenPos;

            // Calculate the scale based on a value (you can replace 'someValue' with your desired variable or calculation)
            float scale = scaleFactor * -cameraController.currentZoomDistance / 10f;

            // Clamp the scale within the specified range
            scale = Mathf.Clamp(scale, minScale, maxScale);
            
            // Apply the scale to the canvas
            transform.localScale = new Vector3(scale, scale, 1f);
        }
    }
}
