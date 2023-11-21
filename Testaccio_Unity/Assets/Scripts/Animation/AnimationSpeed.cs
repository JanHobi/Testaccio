using System.Collections.Generic;
using Calculations;
using UI;
using UnityEngine;

namespace Animation
{
    public class AnimationSpeed : MonoBehaviour
    {
        private float animationPosition;

        [SerializeField] private KnobMove activeCircle;
        [SerializeField] private List<Animator> animators;


        // Update is called once per frame
        void Update()
        {
            CalculateAnimationPosition();
            AndMakeItAlwaysPositive();

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
    }
}
