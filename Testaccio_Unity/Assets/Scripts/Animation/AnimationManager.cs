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

        [SerializeField] private KnobMove activeCircle;
        private SelectAnimator selectAnimator;
        private Animator activeAnimator;

        private void Start()
        {
            // Link
            selectAnimator = GetComponent<SelectAnimator>();
        }

        // Update is called once per frame
        void Update()
        {
            CalculateAnimationPosition();
            AndMakeItAlwaysPositive();
            GetSelectedAnimator();
        }

       

        private void CalculateAnimationPosition()
        {
            animationPosition = ExtensionMethods.Remap(activeCircle.angle, 1, 360, 0, 1);
        }

        private void AndMakeItAlwaysPositive()
        {
            // Avoid Minus Numbers
            if (animationPosition < 0)
            {
                animationPosition = 0;
            }
        }
        
        private void GetSelectedAnimator()
        {
            activeAnimator = selectAnimator.selectedAnimator;
        }

        private void ManipulateAnimator()
        {
            AnimatorStateInfo animState = activeAnimator.GetCurrentAnimatorStateInfo(0);
            float currentTime = animState.normalizedTime % 1;
            animationPosition = currentTime;
        }
    }
}
