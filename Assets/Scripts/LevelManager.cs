using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public UIManager _uiManager;
    public GameManager _gameManager;


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        switch (sceneName)
        {
            case "MainMenu":
                _gameManager.gameState = GameManager.GameState.MainMenu;
                break;
            case "Gameplay_field":
                _gameManager.gameState = GameManager.GameState.Gameplay;
                break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game..");
    }
}
