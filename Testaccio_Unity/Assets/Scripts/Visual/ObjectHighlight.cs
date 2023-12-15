using Audio;
using UnityEngine;

namespace Visual
{
    [RequireComponent(typeof(Outline))]
    public class ObjectHighlight : MonoBehaviour
    { 
        private static bool isClicked = false;

        private void Update()
        {
//            Debug.Log(isClicked);
        }

        private void OnMouseEnter()
        {
            var outline = gameObject.GetComponent<Outline>();
            outline.OutlineWidth = 6f;

            Time.timeScale = 0.35f;
        }

        private void OnMouseExit()
        {
            Time.timeScale = 1f;

            if (!isClicked)
            {
                var outline = gameObject.GetComponent<Outline>();
                outline.OutlineWidth = 0f;
                outline.OutlineColor = Color.white;
            }

            if (isClicked) return;
        }

        public static void ChangeToClickedColor(GameObject obj)
        {
            if (isClicked) return;
            isClicked = true;

            var outline = obj.GetComponent<Outline>();
            outline.OutlineColor = Color.black;
                
            Time.timeScale = 1f;
        }

        public static void RemoveClickedColor(GameObject obj)
        {
                isClicked = false;

                var outline = obj.GetComponent<Outline>();
                outline.OutlineWidth = 0f;
                outline.OutlineColor = Color.white;
        }
    }
}