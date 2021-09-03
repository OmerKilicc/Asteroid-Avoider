using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner _asteroidSpawner;
    public void EndGame()
    {
        _asteroidSpawner.enabled = false;
        gameOverDisplay.gameObject.SetActive(true);
    }
    public void PlayAgain()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }

    public void Continue()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene+1);
    }

    
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Scene_Menu");
    }
    
}
