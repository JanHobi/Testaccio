using System;
using System.Collections.Generic;
using Calculations;
using UI;
using UnityEngine.UI;
using UnityEditor.Rendering;
using UnityEngine;

namespace Animation
{
    public class Knob : MonoBehaviour
    {
        private GameObject myCircle;
        private float knobX;
        private float knobY;
    
        [SerializeField] private float rotationSpeed = 200;
        [HideInInspector] public float angle;
        private float activeAnimSpeed;
        private Vector2 centerPos;
    
        private RectTransform circleRectTransform;
        private RectTransform knobRectTransform;
        
        private bool selected;
        private Animator myAnimator;

        public bool Selected
        {
            get => selected;
            set => selected = value;
        }

        private void OnEnable()
        {
            CircleSizeChange.OnSizeChangeRequested += UpdateScale;
            CircleSizeChange.OnSpeedChangeRequested += UpdateAnimSpeed;
        }

        private void OnDisable()
        {
            CircleSizeChange.OnSizeChangeRequested -= UpdateScale;
            CircleSizeChange.OnSpeedChangeRequested -= UpdateAnimSpeed;
        }

        public void IntializeKnob(GameObject startingCircle, Animator animator)
        {
            myCircle = startingCircle;
            myAnimator = animator;
            centerPos = startingCircle.transform.position;
        
            // Go get the Circle Rect Transform Component
            circleRectTransform = myCircle.GetComponent<RectTransform>();
        
            // Go get the Knob Rect Transform Component
            knobRectTransform = transform.GetComponent<RectTransform>();
            
            CalculateCircleRadius();
            CalculateKnobRadius();
            UpdateAnimSpeed(1);

            AnimatorStateInfo animState = myAnimator.GetCurrentAnimatorStateInfo(0);
            float animationPosition = animState.normalizedTime;
            angle = ExtensionMethods.Remap(animationPosition, 0, 1, 0, 360);
        }
        

        // Update is called once per frame
        void FixedUpdate()
        {
            centerPos = myCircle.transform.position;
            CalculateRotationSpeed();
            TranslateToRadians();
            MoveKnob();
        }

        private void Update()
        {
            ManipulateAnimator();
            ChangeColor();
        }
        
        private void ManipulateAnimator()
        {
            if (myAnimator == null) return;
            myAnimator.speed = activeAnimSpeed;
        }
        
        private void CalculateKnobRadius()
        {
            Vector3 worldscale = knobRectTransform.lossyScale; // Get the local scale factor
            float worldScaleX = worldscale.x; // only take the x-scale factor and put it into a float
        }
        
        private float Radius { get; set; }

        private void CalculateCircleRadius()
        {
            // Calculate Big Circle Radius
            Vector3 worldscale = circleRectTransform.lossyScale; // Get the local scale factor
            float worldScaleX = worldscale.x; // only take the x-scale factor and put it into a float
        
            // Calculate the Radius of the Circle that has this script attached
            Radius = circleRectTransform.sizeDelta.x * 0.5f * worldScaleX;
        }
        

        private void CalculateRotationSpeed()
        {
            float distancePerFrame = rotationSpeed * Time.deltaTime;

        
            angle -= (distancePerFrame / Radius);
         
            if (angle > 360.0f)
            {
                angle -= 360.0f;
            }
        }

        private void TranslateToRadians()
        {
            // Convert angle to radians (in order to be able to use Sin und Cos)
            var radians = Mathf.Deg2Rad * angle;
        
            knobX = centerPos.x + Radius * Mathf.Cos(radians);
            knobY = centerPos.y + Radius * Mathf.Sin(radians);
        }

        private void MoveKnob()
        {
            transform.position = new Vector3(knobX, knobY, 0);
        }

        private void UpdateScale(float activeCircleSize)
        {
            if (!selected) return;
            myCircle.transform.localScale = new Vector3(activeCircleSize, activeCircleSize, activeCircleSize);
            CalculateCircleRadius();
            
        }

        private void UpdateAnimSpeed(float currentSpeed)
        {
            if (!selected) return;
            activeAnimSpeed = currentSpeed;
        }

        private void ChangeColor()
        {
            Image image = gameObject.GetComponent<Image>();
            
            if (selected)
            {
                float selectedAlpha = 1f;
                Color imageColor = image.color;
                imageColor.a = selectedAlpha;
                image.color = imageColor;
            }
            else
            {
                float selectedAlpha = 0f;
                Color imageColor = image.color;
                imageColor.a = selectedAlpha;
                image.color = imageColor;
            }
        }
    }
    }

