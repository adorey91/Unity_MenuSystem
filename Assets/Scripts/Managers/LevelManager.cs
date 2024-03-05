using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = ScriptableObject.FindAnyObjectByType<GameManager>();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
        switch (sceneName)
        {
            case "MainMenu":
                _gameManager.gameState = GameManager.GameState.MainMenu;
                break;
            case "Gameplay_field":
                _gameManager.gameState = GameManager.GameState.Gameplay;
                break;
            case "Gameplay_Scene2":
                _gameManager.gameState = GameManager.GameState.Gameplay;
                break;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game..");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _gameManager.MovePlayerToSpawnPosition();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
