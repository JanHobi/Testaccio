using UnityEngine;

public class FollowObject : MonoBehaviour
{
    // public
    [SerializeField] public Transform target; // Reference to the 3D object you want to follow
    [SerializeField] public float minScale = 0.5f; // Minimum scale for the frame
    [SerializeField] public float maxScale = 2f; // Maximum scale for the frame

    void Update()
    {
        if (target != null)
        {
            // Get the 3D object's screen space bounds
            Bounds bounds = CalculateObjectBounds(target);

            // Calculate the scale factor based on object's size on screen
            float scaleFactor = CalculateScaleFactor(bounds);

            // Clamp the scale within the specified range
            scaleFactor = Mathf.Clamp(scaleFactor, minScale, maxScale);

            // Set the Canvas position to the 3D object's screen position
            Vector3 screenPos = Camera.main.WorldToScreenPoint(target.position);
            transform.position = screenPos;

            // Apply the calculated scale to the canvas
            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
        }
    }

    // Function to calculate object's screen space bounds
    private Bounds CalculateObjectBounds(Transform objTransform)
    {
        Renderer renderer = objTransform.GetComponent<Renderer>();
        Bounds bounds = renderer != null ? renderer.bounds : new Bounds(objTransform.position, Vector3.zero);

        Collider collider = objTransform.GetComponent<Collider>();
        if (collider != null)
        {
            bounds.Encapsulate(collider.bounds);
        }

        return bounds;
    }

    // Function to calculate scale factor based on object's size on screen
    private float CalculateScaleFactor(Bounds bounds)
    {
        // Calculate the object's size on screen
        Vector3 objectSize = Camera.main.WorldToScreenPoint(bounds.max) - Camera.main.WorldToScreenPoint(bounds.min);
        float objectSizeOnScreen = Mathf.Max(objectSize.x, objectSize.y);

        // Calculate the scale factor based on object's size on screen
        float scaleFactor = objectSizeOnScreen / 100f; // You can adjust the division factor based on your scene scale

        return scaleFactor;
    }
}
