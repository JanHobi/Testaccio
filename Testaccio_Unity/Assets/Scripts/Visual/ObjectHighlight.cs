using Audio;
using UnityEngine;
using Managers;


namespace Visual
{
    [RequireComponent(typeof(Outline))]
    public class ObjectHighlight : MonoBehaviour
    { 
        private bool isClicked = false;
        private static bool isPaused = false;
        private GameManager gameManager;

        private void Start()
        {
            gameManager = GameManager.instance;
        }

        private void OnMouseEnter()
        {
            if(gameManager.currentGameState == GameManager.GameState.GamePaused) return;

            var outline = gameObject.GetComponent<Outline>();
            
            outline.OutlineWidth = 6f;
        }

        private void OnMouseExit()
        {
            Debug.Log("Exit");
            if(gameManager.currentGameState == GameManager.GameState.GamePaused) return;
            if (isClicked) return;
            
            var outline = gameObject.GetComponent<Outline>();
            outline.OutlineWidth = 0f;
            outline.OutlineColor = Color.white;
        }

        public void ChangeToClickedColor(GameObject obj)
        {
            isClicked = true;

            var outline = obj.GetComponent<Outline>();
            outline.OutlineColor = Color.black;
                
            Time.timeScale = 1f;
        }

        public void RemoveClickedColor(GameObject obj)
        {
            isClicked = false;

            var outline = obj.GetComponent<Outline>();
            outline.OutlineWidth = 0f;
            outline.OutlineColor = Color.white;
        }
    }
}