using Audio;
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

            // load selected scene
            SetState(currentGameState);

        }
        
        public void SetState(GameState state)
        {
            switch (state)
            {
                case GameState.Menu:

                    if (SceneManager.GetActiveScene().name != "MainMenu")
                    {
                        Time.timeScale = 1;
                        //StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, SceneManager.GetSceneByName(menuScene).buildIndex));
                        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, 0));
                        AudioManager.Instance.PlayMenuMusic();
                        AudioManager.Instance.StopBackgroundSounds();
                    }
                   
                    
                    break;

                case GameState.InGame:

                    if (SceneManager.GetActiveScene().name == "MainMenu")
                    {
                        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, 1));
                        //StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, targetScene.buildIndex));
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
