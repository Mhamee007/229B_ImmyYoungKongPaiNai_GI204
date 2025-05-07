using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TimeCountDown : MonoBehaviour
{
    public TMP_Text timerText;   // UI Text ที่จะใช้แสดงเวลา
    public float timeElapsed; // ตัวแปรเก็บเวลาที่ผ่านไป
    private bool isTimerRunning = true; // ตัวแปรตรวจสอบว่าเวลายังทำงานอยู่หรือไม่

    void Start()
    {
        timeElapsed = 60f;  // เริ่มจับเวลาจาก 60
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed -= UnityEngine.Time.deltaTime;  // ลดเวลาให้กับตัวแปร timeElapsed
            UpdateTimerUI();  // อัพเดท UI ให้แสดงเวลาที่ใช้ไป
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
}
