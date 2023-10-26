using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // The game object to rotate around
    public float rotationSpeed = 1f;
    public float yOffset = 2f;  // Offset in the y-direction

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float rotationAmount = mouseX * rotationSpeed;
            offset = Quaternion.Euler(0, rotationAmount, 0) * offset;
        }

        Vector3 desiredPosition = target.position + offset + new Vector3(0f, yOffset, 0f);
        transform.position = desiredPosition;
        transform.LookAt(target.position);
    }
}
