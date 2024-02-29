using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        // Initialize the score text
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        // Increment the score by 1
        score++;

        // Update the score text
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        // Update the UI text with the current score
        scoreText.text = "Score: " + score;
    }
}
