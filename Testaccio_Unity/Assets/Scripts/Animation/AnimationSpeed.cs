using Calculations;
using UnityEngine;

namespace Animation
{
    public class AnimationSpeed : MonoBehaviour
    {
        private float animationSpeed;
        // Start is called before the first frame update
        void Start()
        {
            animationSpeed = ExtensionMethods.Remap(3, 1, 360, 0, 1);
            Debug.Log(animationSpeed);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
