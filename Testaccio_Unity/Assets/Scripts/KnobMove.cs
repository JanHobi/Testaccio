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
    private bool isCircling;
    private float angle;
    
    private float circleRadius;
    private Vector2 centerPos;
    
    private RectTransform circleRectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        centerPos = transform.position;
        
        // Go get the Rect Transform Component
        circleRectTransform = transform.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCircleRadius();
        CalculateRotationSpeed();
        KnobToCenterDistance();
        MoveKnob();
        //AnimateWithTween();
    }

    private void CalculateCircleRadius()
    {
        Vector3 localScale = circleRectTransform.localScale; // Get the local scale factor
        float scaleX = localScale.x;
        
        // Calculate the Radius of the Circle that has this script attached
        circleRadius = circleRectTransform.sizeDelta.x * 0.5f * scaleX; 
    }

    private void CalculateRotationSpeed()
    {
         angle += Time.deltaTime * rotationSpeed;
         
         if (angle > 360.0f)
         {
             angle -= 360.0f;
         }
    }

    private void KnobToCenterDistance()
    {
        var radians = Mathf.Deg2Rad * angle;
        
         knobX = centerPos.x + circleRadius * Mathf.Cos(radians);
         knobY = centerPos.y + circleRadius * Mathf.Sin(radians);
    }
    
    private void MoveKnob()
    {
        knob.transform.position = new Vector3(knobX, knobY, 0);
    }
    
    private void AnimateWithTween()
    {
        // Move using DoTween
        // knob.DOMove(knobX, knobY, 20);
         
         
    }
}
