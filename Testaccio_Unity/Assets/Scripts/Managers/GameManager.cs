using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

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
        GameResume,
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
        
        // Load Menu at beginning
        //SetState(GameState.Menu);

    }

    /// <summary>
    /// The best possible way to implement this would be
    /// to actually make the game start at this point if needed.
    /// this way we could skip stuff.
    /// </summary>
    public void SetState(GameState state)
    {
        switch (state)
        {
            case GameState.Menu:
                SceneManager.LoadSceneAsync(0);
                StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, SceneManager.GetSceneByName("MainMenu").buildIndex));
                break;

            case GameState.InGame:
                SceneManager.LoadSceneAsync(1);
                StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, SceneManager.GetSceneByName("DomiDev_2").buildIndex));
                break;
            
            case GameState.GamePaused:
                Time.timeScale = 0;
                break;
            
            case GameState.GameResume:
                Time.timeScale = 1;
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
