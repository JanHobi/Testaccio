using System;
using System.Collections.Generic;
using Calculations;
using UI;
using UnityEditor.Build.Content;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

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
            
            //AnimatorStateInfo animState = myAnimator.GetCurrentAnimatorStateInfo(0);
            //float currentTime = RemapValues();
            

            // Set the animator's normalized time based on the calculated animationPosition
            //myAnimator.Play(animState.fullPathHash, 0, currentTime);
            
        }

        private float RemapValues()
        {
            return ExtensionMethods.Remap(angle, 1, 360, 0, 1);
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

        
            angle += (distancePerFrame / Radius);
         
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
            if (myAnimator == null) return;
            activeAnimSpeed = currentSpeed;
            Debug.Log("Animation Speed" + activeAnimSpeed);
        }

        private void ChangeColor()
        {
            if (selected) return;
            //var color = gameObject.GetComponent<Image>().tintColor;
           // color.a = 0.2f;
        }
    }
    }

