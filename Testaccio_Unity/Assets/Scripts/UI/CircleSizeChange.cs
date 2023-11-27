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

        [SerializeField] private List<float> allCircleSizes = new List<float>();


        public static event Action<float> OnSizeChangeRequested; 
        public static event Action<float> OnSpeedChangeRequested; 


        // Start is called before the first frame update
        void Start()
        {
            ActiveCircleSize = 1;
        }
        
        
        
        // Activate the specific button filling and set activeCircleSize
        private void ChangeCircleSize(int index)
        {
            if (index >= 0 && index <= allCircleSizes.Count)
            {
                ActiveCircleSize = allCircleSizes[index]; // Set the new Size of the Circle
            }

            OnSizeChangeRequested?.Invoke(ActiveCircleSize);

            List<float> reversed = allCircleSizes.ToList();
            reversed.Reverse();
            OnSpeedChangeRequested?.Invoke(reversed[index]);
        }

        public void Size1()
        {
            ChangeCircleSize(0);
        }
        public void Size2()
        {
            ChangeCircleSize(1);
        }
        public void Size3()
        {
            ChangeCircleSize(2);
        }
        public void Size4()
        {
            ChangeCircleSize(3);
        }
    }
}
