using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeCountDown : MonoBehaviour
{
    public TMP_Text timerText;   // UI Text �������ʴ�����
    public float timeElapsed; // ����������ҷ���ҹ�
    private bool isTimerRunning = true; // ����õ�Ǩ�ͺ��������ѧ�ӧҹ�����������
   
    
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
            timeElapsed -= UnityEngine.Time.deltaTime;  // Ŵ�������Ѻ����� timeElapsed
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
        // �ŧ�����繹ҷ�����Թҷ�
        int minutes = Mathf.FloorToInt(timeElapsed / 60);
        int seconds = Mathf.FloorToInt(timeElapsed % 60);

        // �ʴ����Һ� UI Text
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetGame()
    {
        Time.timeScale = 1f; // Unpause the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload scene
    }
}
