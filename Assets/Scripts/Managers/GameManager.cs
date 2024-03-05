using System;
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

    public GameObject spawnPoint;
    public GameObject player;
    public GameObject playerArt;
    private PlayerController playerController;

    private void Start()
    {
        
        playerController = player.GetComponent<PlayerController>();
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
    }

    private void MainMenu()
    {
        playerArt.SetActive(false);
        playerController.enabled = false;
        _uiManager.UI_MainMenu();
    }

    private void GamePlay()
    {
        _uiManager.UI_GamePlay();
        if(Input.GetKeyDown(KeyCode.Escape))
            gameState = GameState.Pause;
        
    }

    private void Pause()
    {
        _uiManager.UI_PauseUI();
        if (Input.GetKeyDown(KeyCode.Escape))
            gameState = GameState.Gameplay;
    }

    private void GameWin()
    {
        playerArt.SetActive(false);
        playerController.enabled = false;
        _uiManager.UI_GameWin();
    }

    private void GameOver()
    {
        playerArt.SetActive(false);
        playerController.enabled = false;
        _uiManager.UI_GameOver();
    }

    private void Options()
    {
        playerArt.SetActive(false);
        playerController.enabled = false;
        _uiManager.UI_Options();
    }

    public void MovePlayerToSpawnPosition()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        player.transform.position = spawnPoint.transform.position;
        playerArt.SetActive(true);
        playerController.enabled = true;
    }
}
