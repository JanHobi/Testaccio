using System;
using System.Collections.Generic;
using Calculations;
using UI;
using UnityEngine;


namespace Animation
{
    public class AnimationManager : MonoBehaviour
    {
        private float animationPosition;

        [HideInInspector] public KnobMove knobMove;
        private SelectAnimator selectAnimator;
        private Animator activeAnimator;
        private Dictionary<Animator, float> allAnimationSizes = new Dictionary<Animator, float>();
      
        private void Start()
        {
            // Link
            selectAnimator = GetComponent<SelectAnimator>();
            knobMove = GetComponent<KnobMove>();
        }

        // Update is called once per frame
        void Update()
        {
            CalculateAnimationPosition();
            AndMakeItAlwaysPositive();
            ManipulateAnimator();
        }

        
        private void CalculateAnimationPosition()
        {
            animationPosition = ExtensionMethods.Remap(knobMove.angle, 1, 360, 0, 1);
        }

        private void AndMakeItAlwaysPositive()
        {
            // Avoid Minus Numbers
            if (animationPosition < 0)
            {
                animationPosition = 0;
            }
        }
        
        public void GetSelectedAnimator()
        {
            activeAnimator = selectAnimator.selectedAnimator;
        }
        
        public void ApplyStoredCircleSizes()
        {

            // TryGetValue searches for the value in the dictionary and returns true if found
            if (allAnimationSizes.TryGetValue(activeAnimator, out float storedRadius))
            {
                Debug.Log("Applying Stored Value (" + storedRadius + ") to " + activeAnimator );
                KnobMove.instance.UpdateScale(storedRadius);
            }
            else
            {
                Debug.Log("No stored circle size found for the current animator. Taking Value 50");
                allAnimationSizes.Add(activeAnimator, 1);
                KnobMove.instance.UpdateScale(1);
            }
        }

        private void ManipulateAnimator()
        {
            if (activeAnimator == null) return;

            AnimatorStateInfo animState = activeAnimator.GetCurrentAnimatorStateInfo(0);
            float currentTime = animationPosition;

            // Set the animator's normalized time based on the calculated animationPosition
            activeAnimator.Play(animState.fullPathHash, 0, currentTime);
            
        }

        public void UpdateDictionaryCircleSize()
        {
            if (activeAnimator == null) return;
            
            // Update the dictionary with new circle size when pressing on a circle
            allAnimationSizes[activeAnimator] = CircleSizeChange.ActiveCircleSize;
            
            Debug.Log("Added new Radius (" + KnobMove.instance.Radius +") value to Dictionary index " + activeAnimator);
        }
    }
}
