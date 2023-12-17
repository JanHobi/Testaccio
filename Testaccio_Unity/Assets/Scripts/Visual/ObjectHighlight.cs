using Audio;
using UnityEngine;
using Managers;


namespace Visual
{
    [RequireComponent(typeof(Outline))]
    public class ObjectHighlight : MonoBehaviour
    { 
        private static bool isClicked = false;
        private static bool isPaused = false;
        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameManager.instance;
        }

        private void Update()
        {
            //Debug.Log(isClicked);
        }

        private void OnMouseEnter()
        {
            if(gameManager.currentGameState == GameManager.GameState.GamePaused) return;

            var outline = gameObject.GetComponent<Outline>();
            outline.OutlineWidth = 6f;

            Time.timeScale = 0.35f;
        }

        private void OnMouseExit()
        {
            if(gameManager.currentGameState == GameManager.GameState.GamePaused) return;

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
            /*isClicked = false;

            var outline = obj.GetComponent<Outline>();
            outline.OutlineWidth = 0f;
            outline.OutlineColor = Color.white;*/
        }
    }
}