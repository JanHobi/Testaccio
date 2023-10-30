using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CircleSizeChange : MonoBehaviour
    {
        [HideInInspector] public float activeCircleSize ;

        [SerializeField] private float[] allCircleSizes = new float[4];
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Size1()
        {
            activeCircleSize = allCircleSizes[1];
        }
        public void Size2()
        {
            activeCircleSize = allCircleSizes[2];;
        }
        public void Size3()
        {
            activeCircleSize = allCircleSizes[3];;
        }
        public void Size4()
        {
            activeCircleSize = allCircleSizes[4];;
        }
    }
}
