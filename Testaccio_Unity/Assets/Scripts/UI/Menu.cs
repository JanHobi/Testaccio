using UnityEngine;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        public void SwitchToMenu()
        {
            GameManager.instance.SetState(GameManager.GameState.Menu);
        }

        public void SwitchToGame()
        {
            GameManager.instance.SetState(GameManager.GameState.InGame);
        }

        public void SwitchToCredits()
        {
            GameManager.instance.SetState(GameManager.GameState.Credits);
        }

        public void QuitGame()
        {
            GameManager.instance.SetState(GameManager.GameState.Quit);
        }
        
        public void ResumeGame()
        {
            GameManager.instance.SetState(GameManager.GameState.GameResume);
        }
        
        public void PauseGame()
        {
            GameManager.instance.SetState(GameManager.GameState.GamePaused);
        }
    }
}
