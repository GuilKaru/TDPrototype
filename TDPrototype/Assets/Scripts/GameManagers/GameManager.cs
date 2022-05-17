using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //static variables to see if you won or ended the game
    public static bool gameEnded;
    public static bool gameWon;

    [Header("UI Managers")]
    public GameObject gameOverUI;
    public GameObject pauseUI;
    public GameObject gameWonUI;

    private void Start()
    {
        gameWon = false;
        gameEnded = false;
    }
    private void Update()
    {
        if (gameEnded) return;

        if (gameWon)
        {
            gameEnded = true;
            gameWonUI.SetActive(true);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if(Stats.Lives <= 0)
        {
            gameEnded = true;
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverUI.SetActive(true);

    }

    public void TogglePause()
    {
        pauseUI.SetActive(!pauseUI.activeSelf);

        //Stop time when pause is toggled, resume when you exit it
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void RetryPause()
    {
        //toggle pause to reset the timescale
        TogglePause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
