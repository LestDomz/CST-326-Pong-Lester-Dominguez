using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText; // UI Text for score display
    public TextMeshProUGUI winnerText; // UI text to display winner (Assign in Inspector)
    public AudioSource scoreSound; // Assign an AudioSource for scoring sound

    private int leftPlayerScore = 0;
    private int rightPlayerScore = 0;
    private int winningScore = 11; // Score to win

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(bool isRightPlayer)
    {
        if (isRightPlayer)
            rightPlayerScore++;
        else
            leftPlayerScore++;

        UpdateScoreUI();
        PlayScoreSound();
        CheckGameOver();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = leftPlayerScore + " - " + rightPlayerScore;
    }

    private void CheckGameOver()
    {
        if (leftPlayerScore >= winningScore)
        {
            ShowVictoryMessage("Left Paddle Wins!");
        }
        else if (rightPlayerScore >= winningScore)
        {
            ShowVictoryMessage("Right Paddle Wins!");
        }
    }

    private void ShowVictoryMessage(string winner)
    {
        winnerText.text = winner; // Display winner message
        winnerText.gameObject.SetActive(true); // Show the text
        Invoke(nameof(ResetGame), 3f); // Reset after 3 seconds
    }

    private void ResetGame()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        UpdateScoreUI();
        winnerText.gameObject.SetActive(false); // Hide winner message
    }

    private void PlayScoreSound()
    {
        if (scoreSound != null)
        {
            scoreSound.Play();
        }
    }
}
