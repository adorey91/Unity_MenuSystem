using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [Header("Manager")]
    public GameManager _gameManager;

    public string SceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void LoadScene(string sceneName)
    {
        if(SceneName() != "Options")
            SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _gameManager.MovePlayerToSpawnLocation();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}