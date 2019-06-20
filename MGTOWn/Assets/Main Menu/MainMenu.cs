using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool isGameWasLoaded;

    private void Awake()
    {
        isGameWasLoaded = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        isGameWasLoaded = false;
    }

    public void LoadGame()
    {
        StartGame();

        isGameWasLoaded = true;
    }

    public void QuitGame()
    {
        Debug.Log("Game quited!");
        Application.Quit();
    }
}
