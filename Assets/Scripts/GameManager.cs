using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        Gameplay,
        Pause,
        Options,
        GameOver,
        GameWin,
    }

    public GameState gameState;

    public UIManager _uiManager;
    public LevelManager _levelManager;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.MainMenu:
                MainMenu(); break;
            case GameState.Gameplay:
                GamePlay(); break;
            case GameState.Pause:
                Pause(); break;
            case GameState.Options:
                Options(); break;
            case GameState.GameWin:
                GameWin(); break;
            case GameState.GameOver:
                GameOver(); break;
        }

        if(Input.GetKey(KeyCode.Escape) && gameState == GameState.MainMenu && gameState == GameState.GameWin && gameState == GameState.GameOver)
        {
            if (gameState == GameState.Gameplay)
                gameState = GameState.Pause;
            else
                gameState = GameState.Gameplay;
        }
    }

    private void MainMenu()
    {
        _uiManager.UI_MainMenu();
    }

    private void GamePlay()
    {
        _uiManager.UI_GamePlay();
    }

    private void Pause()
    {
        _uiManager.UI_PauseUI();
    }

    private void GameWin()
    {
        _uiManager.UI_GameWin();
    }

    private void GameOver()
    {
        _uiManager.UI_GameOver();
    }

    private void Options()
    {
        _uiManager.UI_Options();
    }
}
