using UnityEngine;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{

    public void toMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
