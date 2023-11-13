using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class KnobMove : MonoBehaviour
{
    [SerializeField] private GameObject knob;
    private float knobX;
    private float knobY;
    
    [SerializeField] private float rotationSpeed = 200;
    private bool stopCircling;
    private float angle;
    
    private float circleRadius;
    private float knobRadius;
    private Vector2 centerPos;
    
    private RectTransform circleRectTransform;
    private RectTransform knobRectTransform;

    private KnobPlayerInput knobPlayerInput;
    
    // Start is called before the first frame update
    void Start()
    {
        centerPos = transform.position;
        
        // Go get the Circle Rect Transform Component
        circleRectTransform = transform.GetComponent<RectTransform>();
        
        // Go get the Knob Rect Transform Component
        knobRectTransform = knob.GetComponent<RectTransform>();
        
        // Links to other Scripts
        knobPlayerInput = GetComponent<KnobPlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCircleRadius();
        CalculateKnobRadius();
        GetPlayerInputData();
        CalculateRotationSpeed();
        KnobToCenterDistance();
        MoveKnob();
    }
    
    private void CalculateKnobRadius()
    {
        Vector3 worldscale = knobRectTransform.lossyScale; // Get the local scale factor
        float worldScaleX = worldscale.x; // only take the x-scale factor and put it into a float

        // Calculate the Radius of the Nob
        knobRadius = knobRectTransform.sizeDelta.x * 0.5f * worldScaleX; 
        
    }

    private void CalculateCircleRadius()
    {
        // Calculate Big Circle Radius
        Vector3 worldscale = circleRectTransform.lossyScale; // Get the local scale factor
        float worldScaleX = worldscale.x; // only take the x-scale factor and put it into a float
        
        // Calculate the Radius of the Circle that has this script attached
        circleRadius = circleRectTransform.sizeDelta.x * 0.5f * worldScaleX; 
        
    }
    
    private void GetPlayerInputData()
    {
        stopCircling = knobPlayerInput.stopCircling;
    }

    private void CalculateRotationSpeed()
    {
        if (stopCircling)
            return;

        float distancePerFrame = rotationSpeed * Time.deltaTime;

        
        angle += distancePerFrame / circleRadius;
         
        if (angle > 360.0f)
        {
            angle -= 360.0f;
        }
    }

    private void KnobToCenterDistance()
    {
        // Convert angle to radians (in order to be able to use Sin und Cos)
        var radians = Mathf.Deg2Rad * angle;
        
         knobX = centerPos.x + circleRadius * Mathf.Cos(radians);
         knobY = centerPos.y + circleRadius * Mathf.Sin(radians);
    }
    
    private void MoveKnob()
    {
        knob.transform.position = new Vector3(knobX, knobY, 0);
    }
}
