using UnityEngine;
using TMPro;

public class ScoreScene : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int finalScore = GameManager.Instance.score;
        scoreText.text = "Score: " + finalScore;
    }
}
