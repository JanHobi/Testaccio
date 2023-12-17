using Managers;
using UnityEngine;
using FMOD;
using FMODUnity;

namespace UI
{
    public class Menu : MonoBehaviour
    {
        public void SwitchToMenu()
        {
            PlaySound();
            GameManager.instance.SetState(GameManager.GameState.Menu);
        }

        public void SwitchToIntro()
        {
            PlaySound();
            GameManager.instance.SetState(GameManager.GameState.Intro);
        }
        
        public void SwitchToGame()
        {
            PlaySound();
            GameManager.instance.SetState(GameManager.GameState.InGame);
        }


        public void QuitGame()
        {
            PlaySound();
            GameManager.instance.SetState(GameManager.GameState.Quit);
        }

        public void PauseGame()
        {
            PlaySound();
            GameManager.instance.SetState(GameManager.GameState.GamePaused);
        }

        public void SwitchToCredits()
        {
            PlaySound();
        }
        
        public void PlaySound()
        {
            RuntimeManager.PlayOneShot("event:/Sound/UI/ButtonClick");
        }
    }
}
