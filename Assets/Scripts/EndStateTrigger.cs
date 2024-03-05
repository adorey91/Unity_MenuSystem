using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndStateTrigger : MonoBehaviour
{
    private GameManager _gameManager;
    private string stateTrigger;


    private void Start()
    {
        _gameManager = ScriptableObject.FindAnyObjectByType<GameManager>();
    }

    private void ChangeState()
    {
        switch (stateTrigger)
        {
            case GameWin:
                _gameManager.gameState = GameManager.GameState.GameWin; break;
            case GameOver:
                _gameManager.gameState = GameManager.GameState.GameOver; break;
        }
    }


}
