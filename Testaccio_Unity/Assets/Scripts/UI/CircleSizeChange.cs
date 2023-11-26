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
        

        public static event Action<float> OnSizeChangeRequested; 

        // Start is called before the first frame update
        void Start()
        {
            ActiveCircleSize = 1;
        }
        
        
        
        // Activate the specific button filling and set activeCircleSize
        private void ChangeCircleSize(int index)
        {
            if (index >= 0 && index <= allCircleSizes.Length)
            {
                ActiveCircleSize = allCircleSizes[index]; // Set the new Size of the Circle
            }

            OnSizeChangeRequested?.Invoke(ActiveCircleSize);
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
