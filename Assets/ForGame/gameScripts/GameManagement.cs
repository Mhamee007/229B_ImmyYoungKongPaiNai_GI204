using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Projectile2DforBall ballScore;
    private int score = 0;
    public int finalScore;
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keeps this GameObject alive across scenes
        }
        else
        {
            Destroy(gameObject); // Prevents duplicates
        }
    }

    public void SaveScore(int score)
    {
        finalScore = score;
        Debug.Log("Score Saved: " + finalScore);

    }

    public void ResetScore()
    {
        score = 0;
    }


}
