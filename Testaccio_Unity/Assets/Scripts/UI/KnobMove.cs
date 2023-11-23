using System;
using Calculations;
using UnityEngine;

namespace UI
{
    public class KnobMove : MonoBehaviour
    {
        [SerializeField] private GameObject knob;
        private float knobX;
        private float knobY;
    
        [SerializeField] private float rotationSpeed = 200;
        [HideInInspector] public static bool stopCircling;
        [HideInInspector] public float angle;

        private float knobRadius;
        private Vector2 centerPos;
    
        private RectTransform circleRectTransform;
        private RectTransform knobRectTransform;

        private KnobPlayerInput knobPlayerInput;
        
        // Static instance to allow easy access to methods
        public static KnobMove instance;

        private void Awake()
        {
            instance = this;
        }
        
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
        void FixedUpdate()
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
        
        public float Radius { get; set; }

        private void CalculateCircleRadius()
        {
            // Calculate Big Circle Radius
            Vector3 worldscale = circleRectTransform.lossyScale; // Get the local scale factor
            float worldScaleX = worldscale.x; // only take the x-scale factor and put it into a float
        
            // Calculate the Radius of the Circle that has this script attached
            Radius = circleRectTransform.sizeDelta.x * 0.5f * worldScaleX;
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

        
            angle += (distancePerFrame / Radius);
         
            if (angle > 360.0f)
            {
                angle -= 360.0f;
            }
        }

        private void KnobToCenterDistance()
        {
            // Convert angle to radians (in order to be able to use Sin und Cos)
            var radians = Mathf.Deg2Rad * angle;
        
            knobX = centerPos.x + Radius * Mathf.Cos(radians);
            knobY = centerPos.y + Radius * Mathf.Sin(radians);
        }
    
        private void MoveKnob()
        {
            knob.transform.position = new Vector3(knobX, knobY, 0);
        }

        public static void JumpToAnimator(Animator selectedAnimator)
        {
            // When the player selects a new object, the knob has to jump to the current frame of the animtion
            if (instance != null && selectedAnimator != null)
            {
                instance.angle = ExtensionMethods.Remap(selectedAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime, 0, 1, 1,
                    360);
            }
        }

        public void UpdateScale(float activeCircleSize)
        {
            transform.localScale = new Vector3(activeCircleSize, activeCircleSize, activeCircleSize);
            CalculateCircleRadius();
        }
    }
}
