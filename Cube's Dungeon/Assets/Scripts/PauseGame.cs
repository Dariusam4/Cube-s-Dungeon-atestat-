using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public void isPauseGame()
    {
        Time.timeScale = 0f;
    }

    public void toMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
