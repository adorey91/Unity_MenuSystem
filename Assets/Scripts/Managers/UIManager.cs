using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject mainMenuUI;
    public GameObject pauseUI;
    public GameObject gamePlayUI;
    public GameObject optionsUI;
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public void UI_MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;

        mainMenuUI.SetActive(true);
        pauseUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    public void UI_GamePlay()
    {
        Cursor.lockState= CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;

        mainMenuUI.SetActive(false);
        pauseUI.SetActive(false);
        gamePlayUI.SetActive(true);
        optionsUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    public void UI_PauseUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        mainMenuUI.SetActive(false);
        pauseUI.SetActive(true);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }

    public void UI_GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        mainMenuUI.SetActive(false);
        pauseUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        gameOverUI.SetActive(true);
        gameWinUI.SetActive(false);
    }

    public void UI_GameWin()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        mainMenuUI.SetActive(false);
        pauseUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(false);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(true);
    }

    public void UI_Options()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;

        mainMenuUI.SetActive(false);
        pauseUI.SetActive(false);
        gamePlayUI.SetActive(false);
        optionsUI.SetActive(true);
        gameOverUI.SetActive(false);
        gameWinUI.SetActive(false);
    }
}
