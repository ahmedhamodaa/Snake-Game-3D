using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter : MonoBehaviour
{
    public string pauseMenuSceneName = "PauseMenu";

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        SceneManager.LoadScene(pauseMenuSceneName, LoadSceneMode.Additive);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.UnloadSceneAsync(pauseMenuSceneName);
    }

    public void Level1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Level2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
    public void Level3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Levels");

    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
