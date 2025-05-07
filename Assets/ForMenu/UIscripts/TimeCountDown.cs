using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class TimeCountDown : MonoBehaviour
{
    public TMP_Text timerText;   // UI Text �������ʴ�����
    public float timeElapsed; // ����������ҷ���ҹ�
    private bool isTimerRunning = true; // ����õ�Ǩ�ͺ��������ѧ�ӧҹ�����������

    void Start()
    {
        timeElapsed = 60f;  // ������Ѻ���Ҩҡ 60
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timeElapsed -= UnityEngine.Time.deltaTime;  // Ŵ�������Ѻ����� timeElapsed
            UpdateTimerUI();  // �Ѿഷ UI ����ʴ����ҷ�����
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
}
