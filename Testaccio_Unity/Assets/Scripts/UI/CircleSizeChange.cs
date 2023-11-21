using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    public class CircleSizeChange : MonoBehaviour
    {
        [HideInInspector] public float activeCircleSize ;

        [SerializeField] private float[] allCircleSizes = new float[4];
        
        [SerializeField] private Transform selectedCircle;
   
        
        
        // Start is called before the first frame update
        void Start()
        {
            activeCircleSize = 1;
        }
        
        
        
        // Activate the specific button filling and set activeCircleSize
        private void ActivateButtonFilling(int index)
        {
            if (index >= 0 && index <= allCircleSizes.Length)
            {
                activeCircleSize = allCircleSizes[index]; // Set the new Size of the Circle
                
                ApplyCircleSize();
            }
            else
            {
                Debug.LogError("Index out of range: " + index);
            }

            void ApplyCircleSize()
            {
                selectedCircle.localScale = new Vector3(activeCircleSize, activeCircleSize, activeCircleSize);
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
