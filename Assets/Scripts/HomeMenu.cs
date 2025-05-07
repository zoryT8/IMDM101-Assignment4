using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public void loadDifficultyScreen() {
        SceneManager.LoadScene("Difficulty Select");
    }

    public void startEasy() {
        SceneManager.LoadScene("Level1 - Easy");
    }

    public void startMedium() {
        SceneManager.LoadScene("Level2 - Medium");
    }

    public void startImpossible() {
        SceneManager.LoadScene("Level3 - Hard");
    }

    public void returnToHome() {
        SceneManager.LoadScene("Home Screen");
    }

    public void quit() {
        Debug.Log("quit");
        Application.Quit();
    }
}
