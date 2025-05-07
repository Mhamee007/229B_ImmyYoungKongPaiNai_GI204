using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonmanage : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
