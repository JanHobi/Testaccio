using System;
using Audio;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        public GameState currentGameState;

        /// <summary>
        /// Possible gamestates.
        /// </summary>
        public enum GameState
        {
            Menu,
            InGame,
            GamePaused,
            GameWon,
            Quit
        }

        /// <summary>
        /// Setup game manager.
        /// Is built as a singleton. This way, we can access some things
        /// from everywhere.
        /// </summary>
        private void Awake()
        {
            // singleton
            if (instance == null) instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            // let's keep this manager for ever and ever and ever and ever...
            DontDestroyOnLoad(instance);
        }

        private void Start()
        {
            // load selected scene
            SetState(currentGameState);
        }

        public void SetState(GameState state)
        {
            switch (state)
            {
                case GameState.Menu:

                    AudioManager.Instance.PlayMenuMusic();
                    AudioManager.Instance.StopInGameBackgroundSounds();
                    
                    if (SceneManager.GetActiveScene().name == "MainMenu") return;
                    
                        Time.timeScale = 1;
                        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, 0));


                    break;

                case GameState.InGame:

                    if (SceneManager.GetActiveScene().name == "MainMenu")
                    {
                        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, 1));
                        AudioManager.Instance.PlayGameMusic();
                        AudioManager.Instance.PlayBackgroundSounds();
                            
                        
                    }
                    else
                    {
                        Time.timeScale = 1;
                    }
                    break;
            
                case GameState.GamePaused:
                    Time.timeScale = 0;
                    break;
                
                case GameState.GameWon:
                    Time.timeScale = 1;
                    break;
                case GameState.Quit:
                    Application.Quit();
                    break;
            }

            currentGameState = state;
            Debug.Log("GAMESTATE: " + currentGameState);

        }
    }
}
