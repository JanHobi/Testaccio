using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class KnobPlayerInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [HideInInspector] public bool stopCircling;
   
        private static bool PlayerClick()
        {
            return Input.GetMouseButton(0);
        }
   
        public void OnPointerDown(PointerEventData eventData)
        {
            stopCircling = true;
            Debug.Log(stopCircling);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            stopCircling = false;
        }
    }
}
