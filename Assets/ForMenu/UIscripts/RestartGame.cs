using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public string sceneName;
    private Button button;    // Reference to the button

    void Start()
    {
        button = GetComponent<Button>();

        // Ensure button is assigned and add a click event
        if (button != null)
        {
            button.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogError("Button component not found!");
        }
    }

    void ChangeScene()
    {
        Time.timeScale = 1f; //re speed game
        GameManager.Instance.ResetScore();
        SceneManager.LoadScene(sceneName);

    }
}
