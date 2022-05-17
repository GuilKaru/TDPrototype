using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Main Menu UI")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject levelSelect;
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LevelSelect()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Return()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void LevelTwoChange()
    {
        SceneManager.LoadScene("Level2");
    }
}
