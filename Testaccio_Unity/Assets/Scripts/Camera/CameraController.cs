using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // The game object to rotate around
    public float rotationSpeed = 1f;
    public float zoomSpeed = 5f; // Zoom speed
    public float minZoomDistance = 2f; // Minimum distance from the target
    public float maxZoomDistance = 10f; // Maximum distance from the target
    public Vector3 targetOffset; // Offset from the target's position

    public float currentZoomDistance;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - (target.position + targetOffset);
        currentZoomDistance = offset.magnitude;
    }

    void Update()
    {
        // Rotation based on mouse X movement
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float rotationAmount = mouseX * rotationSpeed;
            offset = Quaternion.Euler(0, rotationAmount, 0) * offset;
        }

        // Zoom in/out with mouse wheel
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        currentZoomDistance -= zoomInput * zoomSpeed;
        currentZoomDistance = Mathf.Clamp(currentZoomDistance, minZoomDistance, maxZoomDistance);

        // Update camera position and rotation
        Vector3 zoomOffset = offset.normalized * currentZoomDistance;
        Vector3 desiredPosition = target.position + targetOffset + zoomOffset;
        transform.position = desiredPosition;
        transform.LookAt(target.position + targetOffset);

        Debug.Log(currentZoomDistance);
    }
}
