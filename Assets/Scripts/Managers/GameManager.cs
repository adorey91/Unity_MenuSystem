using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        GamePlay,
        Pause,
        Options,
        GameOver,
        GameWin,
    }

    public GameState gameState;

    [Header("Other Managers")]
    public UIManager _uiManager;
    public LevelManager _levelManager;
    string stateBeforeOptions;

    [Header("Text UI")]
    [SerializeField] TMP_Text currentState;
    [SerializeField] TMP_Text currentScene;

    public GameObject spawnPoint;
    public GameObject player;


    public void Start()
    {
        gameState = GameState.MainMenu;
    }

    public void Update()
    {
        if (_levelManager.SceneName() != "Options")
        {
            if (_levelManager.SceneName() != stateBeforeOptions)
                stateBeforeOptions = _levelManager.SceneName();
        }

        switch (gameState)
        {
            case GameState.MainMenu: MainMenu(); break;
            case GameState.GamePlay: GamePlay(); break;
            case GameState.Pause: Pause(); break;
            case GameState.Options: Options(); break;
            case GameState.GameWin: GameWin(); break;
            case GameState.GameOver: GameOver(); break;
        }
    }

    void MainMenu()
    {
        _uiManager.UI_MainMenu();
    }

    void GamePlay()
    {
        _uiManager.UI_GamePlay();
        if (Input.GetKeyDown(KeyCode.Escape))
            gameState = GameState.Pause;
    }

    void Pause()
    {
        _uiManager.UI_Pause();
        if (Input.GetKeyDown(KeyCode.Escape))
            gameState = GameState.GamePlay;
    }

    void GameWin()
    {
        _uiManager.UI_GameWin();
    }

    void GameOver()
    {
        _uiManager.UI_GameOver();
    }

    void Options()
    {
        _uiManager.UI_Options();
        if (Input.GetKeyDown(KeyCode.Escape))
            _levelManager.LoadScene(stateBeforeOptions);
    }

    public void MovePlayerToSpawnLocation()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        player.transform.position = spawnPoint.transform.position;
    }
}