using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void MainSceneLoad()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
