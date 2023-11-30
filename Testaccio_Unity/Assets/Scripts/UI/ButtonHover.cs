using UnityEngine;

namespace UI
{
    public class ButtonHover : MonoBehaviour
    {

        private Vector3 normalScale;
    
        // Start is called before the first frame update
        void Start()
        {
            normalScale = transform.localScale;
        }

        public void HoverIn()
        {
            transform.localScale *= (float) 1.1;
        }

        public void HoverOut()
        {
            transform.localScale = normalScale;
        }
    }
}
