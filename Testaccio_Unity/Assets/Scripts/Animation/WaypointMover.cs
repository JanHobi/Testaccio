using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    public float moveSpeed = 5f;
    private Transform targetWaypoint;

    void Start()
    {
        targetWaypoint = waypoint1;
    }

    void Update()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, step);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            if (targetWaypoint == waypoint1)
            {
                targetWaypoint = waypoint2;
            }
            else
            {
                targetWaypoint = waypoint1;
            }
        }
    }
}
