using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public bool resetScoreOnLoad = false;

    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = ("Score: " + score);

        if (resetScoreOnLoad)
        {
            score = 0;
            scoreText.text = ("Score: " + score);
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = ("Score: " + score);
    }
}
