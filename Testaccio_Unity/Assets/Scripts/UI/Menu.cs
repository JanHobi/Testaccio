using Managers;
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

        public void QuitGame()
        {
            GameManager.instance.SetState(GameManager.GameState.Quit);
        }

        public void PauseGame()
        {
            GameManager.instance.SetState(GameManager.GameState.GamePaused);
        }
    }
}
