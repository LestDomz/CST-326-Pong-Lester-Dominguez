using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TextMeshProUGUI scoreText; // UI Text for score display

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
        scoreText.text = "Game Over\n" + winner; // Display the victory message
        Invoke(nameof(ResetGame), 3f); // Reset after 3 seconds
    }

    private void ResetGame()
    {
        leftPlayerScore = 0;
        rightPlayerScore = 0;
        UpdateScoreUI(); // Reset score display
    }
}
