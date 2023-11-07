using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using DG.Tweening;

public class SceneManagement : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    
    public void PlayGame() 
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, SceneManager.GetActiveScene().buildIndex +1));
    }
    
    public void QuitGame() 
    {
        Application.Quit();
    }
}
