using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class SceneManagement : MonoBehaviour
    {
        void Update()
        {
           
        }
    
        public void PlayGame() 
        {
            //StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, SceneManager.GetActiveScene().buildIndex +1));
        }
    
        public void QuitGame() 
        {
            
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void BackToMenu()
        {
            Time.timeScale = 1;
            //StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, SceneManager.GetActiveScene().buildIndex -1));
        }
    }
}
