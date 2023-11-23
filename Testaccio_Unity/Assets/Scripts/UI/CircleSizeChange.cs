using System;
using System.Collections.Generic;
using System.Linq;
using Animation;
using UnityEngine;

namespace UI
{
    public class CircleSizeChange : MonoBehaviour
    {
        [HideInInspector] public static float ActiveCircleSize ;

        [SerializeField] private float[] allCircleSizes = new float[4];
        
        [SerializeField] private Transform selectedCircle;

        [SerializeField] private AnimationManager _animationManager;

        // Start is called before the first frame update
        void Start()
        {
            ActiveCircleSize = 1;
        }
        
        
        
        // Activate the specific button filling and set activeCircleSize
        private void ActivateButtonFilling(int index)
        {
            if (index >= 0 && index <= allCircleSizes.Length)
            {
                ActiveCircleSize = allCircleSizes[index]; // Set the new Size of the Circle
                
                KnobMove.instance.UpdateScale(ActiveCircleSize);
                _animationManager.UpdateDictionaryCircleSize();
            }
            else
            {
                Debug.LogError("Index out of range: " + index);
            }
        }

        public void Size1()
        {
            ActivateButtonFilling(0);
        }
        public void Size2()
        {
            ActivateButtonFilling(1);
        }
        public void Size3()
        {
            ActivateButtonFilling(2);
        }
        public void Size4()
        {
            ActivateButtonFilling(3);
        }
    }
}
