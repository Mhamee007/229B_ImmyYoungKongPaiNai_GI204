using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCountDown : MonoBehaviour
{
    public string sceneName;
    public TMP_Text timerText;       // UI Text to display time
    public GameObject EndScreen;
    public Button resetButton;

    public float timeElapsed = 60f;
    private bool isTimerRunning = true;

    void Start()
    {
       

        timeElapsed = 60f;
        EndScreen.SetActive(false);
        resetButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed -= Time.deltaTime;
            if (timeElapsed <= 0)
            {
                timeElapsed = 0;
                isTimerRunning = false;
                Time.timeScale = 0f; // Pause the game
                EndScreen.SetActive(true);
                resetButton.gameObject.SetActive(true);
                resetButton.onClick.RemoveAllListeners(); // Prevent multiple listeners
                
            }

            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

  

   
}
