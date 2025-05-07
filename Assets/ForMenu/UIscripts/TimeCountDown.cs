using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCountDown : MonoBehaviour
{
    public TMP_Text timerText;   // UI Text ที่จะใช้แสดงเวลา
    public float timeElapsed; // ตัวแปรเก็บเวลาที่ผ่านไป
    private bool isTimerRunning = true; // ตัวแปรตรวจสอบว่าเวลายังทำงานอยู่หรือไม่
   
    
    public GameObject EndScreen;
    public Button resetButton;
    

    void Start()
    {
        timeElapsed = 60f;
        EndScreen.SetActive(false);
       

    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed -= UnityEngine.Time.deltaTime;  // ลดเวลาให้กับตัวแปร timeElapsed
            if (timeElapsed <= 0)
            {
                timeElapsed = 0;
                isTimerRunning = false;
                Time.timeScale = 0f;              // Pause the game
                EndScreen.SetActive(true);
                resetButton.onClick.AddListener(ResetGame);// Show reset button

            }

            UpdateTimerUI();
        }
    }
   


    void UpdateTimerUI()
    {
        // แปลงเวลาเป็นนาทีและวินาที
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        // แสดงเวลาบน UI Text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetGame()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
    }
}
