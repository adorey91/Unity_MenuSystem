using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    GameState currentState;
    GameState stateBeforeOptions;

    [Header("Other Managers")]
    public UIManager _uiManager;
    public LevelManager _levelManager;

    [Header("Text UI")]
    [SerializeField] TMP_Text currentStateText;
    [SerializeField] TMP_Text currentScene;

    public GameObject spawnPoint;
    public GameObject player;


    public void Start()
    {
        gameState = GameState.MainMenu;
        StateSwitch();

        currentStateText.text = $"State: {gameState}";
        currentScene.text = $"Scene: {SceneManager.GetActiveScene().name}";
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            EscapeState();

        if (gameState != currentState)
            StateSwitch();

        currentStateText.text = $"State: {gameState}";
        currentScene.text = $"Scene: {SceneManager.GetActiveScene().name}";
    }

    public void StateSwitch()
    {
        switch (gameState)
        {
            case GameState.MainMenu: MainMenu(); break;
            case GameState.Gameplay: GamePlay(); break;
            case GameState.Pause: Pause(); break;
            case GameState.Options: Options(); break;
            case GameState.GameWin: GameWin(); break;
            case GameState.GameOver: GameOver(); break;
        }
        currentState = gameState;
    }

    void EscapeState()
    {
        if (currentState == GameState.Gameplay)
            LoadState("Pause");
        else if (currentState == GameState.Pause)
            LoadState("Gameplay");
        else if (currentState == GameState.Options)
            LoadState(stateBeforeOptions.ToString());
    }

    #region LoadState/Quit
    public void LoadState(string state)
    {
        if (state == "Options")
        {
            stateBeforeOptions = currentState;
            gameState = GameState.Options;
        }
        else if (state == "MainMenu")
            gameState = GameState.MainMenu;
        else if (state == "Pause")
            gameState = GameState.Pause;
        else if (state == "Gameplay")
            gameState = GameState.Gameplay;
        else if (state == "GameOver")
            gameState = GameState.GameOver;
        else if (state == "GameWin")
            gameState = GameState.GameWin;
        else if (state == "BeforeOptions")
            gameState = stateBeforeOptions;
        else
            Debug.Log("State doesnt exist");
    }

    public void EndGame()
    {
        Application.Quit();
        Debug.Log("Quittin Game");
    }
    #endregion

    #region StateUI-Update
    void MainMenu()
    {
        _uiManager.UI_MainMenu();
    }

    void GamePlay()
    {
        _uiManager.UI_GamePlay();
    }

    void Pause()
    {
        _uiManager.UI_Pause();
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
    }
    #endregion

    public void MovePlayerToSpawnLocation()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        player.transform.position = spawnPoint.transform.position;
    }
}