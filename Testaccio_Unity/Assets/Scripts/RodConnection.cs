using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodConnection : MonoBehaviour
{
    [SerializeField] private GameObject hook;
    [SerializeField] private GameObject rodEnd;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, rodEnd.transform.position);
        lineRenderer.SetPosition(1, hook.transform.position);
    }
}
