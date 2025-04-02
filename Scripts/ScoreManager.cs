using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winnerText;

    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    private int maxScore = 5;

    public int ScorePlayer1 => scorePlayer1;
    public int ScorePlayer2 => scorePlayer2;

    public void Player1Scores()
    {
        scorePlayer1++;
        UpdateScore();

        if (scorePlayer1 >= maxScore)
        {
            EndGame("Teddy gewinnt!");
        }
    }

    public void Player2Scores()
    {
        scorePlayer2++;
        UpdateScore();

        if (scorePlayer2 >= maxScore)
        {
            EndGame("Panda gewinnt!");
        }
    }

    private void UpdateScore()
    {
        scoreText.text = scorePlayer1 + " - " + scorePlayer2;
    }

    private void EndGame(string winnerMessage)
    {
        winnerText.text = winnerMessage;
        winnerText.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log(winnerMessage);
    }
}
