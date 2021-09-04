using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner _asteroidSpawner;
    public void EndGame()
    {
        _asteroidSpawner.enabled = false;

        scoreSystem.isCounting = false;
        scoreSystem.TextMeshPro.text = string.Empty;
        gameOverText.text = "Final Score: " + Mathf.FloorToInt(scoreSystem.score).ToString();

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
