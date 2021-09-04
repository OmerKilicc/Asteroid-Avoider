using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Button continueButton;

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

    public void ContinueButton()
    {
        
        AdManager.Instance.ShowAd(this);
        continueButton.interactable = false;
    }

    public void ContinueGame()
    {
        scoreSystem.Startimer();
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _asteroidSpawner.enabled = true;
        gameOverDisplay.gameObject.SetActive(false);
    }

    
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Scene_Menu");
    }
    
}
