using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        public GameState currentGameState;
        [SerializeField] private string inGameScene;
    
        /// <summary>
        /// Possible gamestates.
        /// </summary>
        public enum GameState
        {
            Menu,
            InGame,
            GamePaused,
            GameOver,
            GameWon,
            Credits,
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
                    SceneManager.LoadSceneAsync(0);
                    StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, SceneManager.GetSceneByName("MainMenu").buildIndex));
                    break;

                case GameState.InGame:
                    if (SceneManager.GetActiveScene().name == "MainMenu")
                    {
                        SceneManager.LoadSceneAsync(1);
                        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, SceneManager.GetSceneByName(inGameScene).buildIndex));
                    }
                    else
                    {
                        Time.timeScale = 1;
                    }
                
                    break;
            
                case GameState.GamePaused:
                    Time.timeScale = 0;
                    break;

                case GameState.GameOver:
                
                    break;
                case GameState.GameWon:
                
                    break;
                case GameState.Credits:
                
                    break;
                case GameState.Quit:
                    Application.Quit();
                    break;
            }

            currentGameState = state;

        }
    }
}
