using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text gameOverText;
    public GameObject gameOverScreen;
    public bool finished = false;

    AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // good for testing
    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore += 1;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    [ContextMenu("Reset Score")]
    public void resetScore()
    {
        playerScore = 0;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        if (playerScore < 20)
        {
            gameOverText.text = "You Lost!";
            audioManager.PlaySFX(audioManager.lose);
        } else
        {
            gameOverText.text = "You Win!";
            audioManager.PlaySFX(audioManager.win);
        }
        gameOverScreen.SetActive(true);
        finished = true;
    }
}
